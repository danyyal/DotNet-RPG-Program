using AutoMapper;
using CourseProgram.Dtos.Character;
using CourseProgram.Dtos.Fight;
using CourseProgram.Dtos.Skills;
using CourseProgram.Dtos.Weapon;
using CourseProgram.Models;
using Program.Models;
using System.Linq;

namespace CourseProgram
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto=>dto.Skills,c=>c.MapFrom(c=>c.CharacterSkills.Select(cs=>cs.Skill)));
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Character, HighScoreDto>();

        }
    }
}
