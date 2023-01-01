using CourseProgram.Dtos.Character;
using CourseProgram.Models;
using CourseProgram.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseProgram.Controllers
{
    [Authorize(Roles ="Player,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class characterController : ControllerBase
    {
        //for single character only
        // private static Character knight = new Character();

/*
        //for multiple characters 
        private static List<Character> MyCharacters = new List<Character> {
            new Character(),
            new Character{Id=1, Name="Sam"},
            new Character{Id=2, Defense=9}
        };*/

        private readonly ICharacterService _characterService;
        public characterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        /*
         * to allow unauthenticated users as well to get the results
         * Write this atttribute above the get method to avail this feature
         * [AllowAnonymous]
        */
        
        [HttpGet("GetAll")]
        public async  Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        
        [HttpGet("GetFirst")]
        public async Task<IActionResult> GetSingle()
        {
            return Ok(await _characterService.GetFirstCharacter());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

 
        [HttpPost]
        public async Task<IActionResult> Addcharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> Updatecharacter(UpdateCharacterDto UpdatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(UpdatedCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}


