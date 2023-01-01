using AutoMapper;
using CourseProgram.Data;
using CourseProgram.Dtos.Character;
using CourseProgram.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CourseProgram.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        
        private static List<Character> MyCharacters = new List<Character> {
            new Character(),
            new Character{Id=1, Name="Sam"},
            new Character{Id=2, Defense=9}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Characters.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c)).ToList());
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
                if (character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = (_context.Characters.Where(c => c.User.Id == GetUserId())
                        .Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character Not Found Or Not Assosiated with you";

                }

            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            //To get all the charcters from the database
            List<Character> DbCharacters = 
                GetUserRole().Equals("Admin")? await _context.Characters.ToListAsync():
                await _context.Characters.Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = (DbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();

            //To get all the characters from the list
            /*
             * serviceResponse.Data = (MyCharacters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            */
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character DbCharacter = await _context.Characters
                .Include(c => c.Weapon)
                    .Include(c => c.CharacterSkills).ThenInclude(c => c.Skill)
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            //to get the data from the list
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(DbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetFirstCharacter()
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

            List<Character> DbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = DbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).FirstOrDefault();
            //to get the data from the list
            // serviceResponse.Data = MyCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).FirstOrDefault();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {


                Character character = await _context.Characters.Include(c=>c.User).FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                if (character.User.Id == GetUserId())
                {
                    character.Name = updatedCharacter.Name;
                    character.Strength = updatedCharacter.Strength;
                    character.Intelligence = updatedCharacter.Intelligence;
                    character.Class = updatedCharacter.Class;
                    character.Defense = updatedCharacter.Defense;
                    character.HitPoints = updatedCharacter.HitPoints;

                    //Why there is need to implement Update method 
                    //when the database is updated without this method
                    //_context.Characters.Update(character);

                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Either the Character donot exist or the character you are trying to update is not assosiated with you";
                }

            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }


        //Method to get the user id of the current user 
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        private string GetUserRole () => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);


    }
}
