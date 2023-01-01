using CourseProgram.Dtos.Character;
using CourseProgram.Models;
using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProgram.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        public Task<ServiceResponse<GetCharacterDto>> GetFirstCharacter();
        public Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        public Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        public Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        public Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}
