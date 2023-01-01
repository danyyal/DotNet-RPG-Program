using AutoMapper;
using CourseProgram.Data;
using CourseProgram.Dtos.Fight;
using CourseProgram.Models;
using Microsoft.EntityFrameworkCore;
using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProgram.Services.FightService
{
    public class FightService: IFightService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FightService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
        {
            ServiceResponse<AttackResultDto> serviceResponse = new ServiceResponse<AttackResultDto>();

            try
            {
                Character attacker = await _context.Characters
                    .Include(c => c.Weapon)
                    .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Character opponent = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == request.OpponentId);

                if (request.AttackerId == request.OpponentId)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character cannot attack itself";
                    return serviceResponse;
                }
                /*
                 * Damage formula
                 * We can write the formula of our own choice
                 */
                int damage = WeaponAttack(attacker, opponent);
                if (opponent.HitPoints <= 0)
                    serviceResponse.Message = $"{opponent.Name} has been defeated by the attacker {attacker.Name}";

                _context.Characters.Update(opponent);
                await _context.SaveChangesAsync();


                serviceResponse.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    AttackerHP = attacker.HitPoints,
                    Opponent = opponent.Name,
                    OpponentHP = opponent.HitPoints,
                    Damage = damage
                };
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        private static int WeaponAttack(Character attacker, Character opponent)
        {
            int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
            damage -= new Random().Next(opponent.Defense);

            if (damage > 0)
                opponent.HitPoints -= damage;
            return damage;
        }

        public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request)
        {
            ServiceResponse<AttackResultDto> serviceResponse = new ServiceResponse<AttackResultDto>();

            try
            {
                Character attacker = await _context.Characters
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Character opponent = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == request.OpponentId);



                //getting the skills of the character (Attacker)
                CharacterSkill characterSkill = attacker.CharacterSkills.FirstOrDefault(cs => cs.Skill.Id == request.SkillId);

                //to check if the skills of characters are null or not
                if (characterSkill == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character donot know this skill";
                    return serviceResponse;
                }


                //To check if the user is attacking itseld or not because self attacking is not allowed
                if (request.AttackerId == request.OpponentId)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character cannot attack itself";
                    return serviceResponse;
                }
                /*
                 * Damage formula
                 * We can write the formula of our own choice
                 */
                int damage = SkillAttack(attacker, opponent, characterSkill);
                if (opponent.HitPoints <= 0)
                    serviceResponse.Message = $"{opponent.Name} has been defeated by the attacker {attacker.Name}";

                _context.Characters.Update(opponent);
                await _context.SaveChangesAsync();


                serviceResponse.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    AttackerHP = attacker.HitPoints,
                    Opponent = opponent.Name,
                    OpponentHP = opponent.HitPoints,
                    Damage = damage
                };
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        private static int SkillAttack(Character attacker, Character opponent, CharacterSkill characterSkill)
        {
            int damage = characterSkill.Skill.Damage + (new Random().Next(attacker.Intelligence));
            damage -= new Random().Next(opponent.Defense);

            if (damage > 0)
                opponent.HitPoints -= damage;
            return damage;
        }

        public async Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request)
        {
            ServiceResponse<FightResultDto> serviceResponse = new ServiceResponse<FightResultDto>
            {
                Data=new FightResultDto()
            };
            try
            {
                List<Character> characters =
                    await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .Where(c => request.CharacterIds.Contains(c.Id)).ToListAsync();

                bool defeated = false;
                while (!defeated)
                {
                    foreach(Character attacker in characters)
                    {
                        List<Character> opponents = characters.Where(c => c.Id != attacker.Id).ToList();
                        Character opponent = opponents[new Random().Next(opponents.Count)];

                        int damage = 0;
                        string attackUsed = string.Empty;

                        bool useWeapon = new Random().Next(2) == 0;
                        if (useWeapon)
                        {
                            attackUsed = attacker.Weapon.name;
                            damage = WeaponAttack(attacker, opponent);
                            
                        }
                        else
                        {
                            int randomSkill = new Random().Next(attacker.CharacterSkills.Count);
                            attackUsed = attacker.CharacterSkills[randomSkill].Skill.Name;
                            damage = SkillAttack(attacker, opponent, attacker.CharacterSkills[randomSkill]);

                        }
                        serviceResponse.Data.log.Add($"{attacker.Name} Attacked {opponent.Name} using {attackUsed} causing {(damage >= 0 ? damage : 0)} damage ");

                        if (opponent.HitPoints <= 0)
                        {
                            defeated = true;
                            attacker.Victories++;
                            opponent.Defeats++;
                            serviceResponse.Data.log.Add($"{opponent.Name} has been defeated!");
                            serviceResponse.Data.log.Add($"{attacker.Name} wins with {attacker.HitPoints} Hitpoints Left!");
                            break;
                        }
                    }
                }
                characters.ForEach(c =>
                {
                    c.Fights++;
                    c.HitPoints = 500;
                });
                _context.Characters.UpdateRange(characters);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<HighScoreDto>>> GetHighScore()
        {
            List<Character> characters = await _context.Characters
                .Where(c => c.Fights > 0)
                .OrderByDescending(c => c.Victories)
                .ThenBy(c => c.Defeats)
                .ToListAsync();

            var serviceResponse = new ServiceResponse<List<HighScoreDto>>
            {
                Data = characters.Select(c => _mapper.Map<HighScoreDto>(c)).ToList()
            };

            return serviceResponse;
        }
    }
}
