using AutoMapper;
using CourseProgram.Data;
using CourseProgram.Dtos.Character;
using CourseProgram.Dtos.Weapon;
using CourseProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Program.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CourseProgram.Services.WeaponService
{
    public class WeaponService :IWeaponService
    {
        private readonly DataContext _contex;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context,IHttpContextAccessor htppContextAccessor,IMapper mapper)
        {
            _contex = context; 
            _httpContextAccessor = htppContextAccessor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character character = await _contex.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && 
                    c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (character == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character Not Found";
                }
                Weapon weapon = new Weapon
                {
                    name = newWeapon.Name,
                    Damage=newWeapon.Damage,
                    Character=character
                };
                await _contex.Weapons.AddAsync(weapon);
                await _contex.SaveChangesAsync();


                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = (e.Message);
            }
            return serviceResponse;
        }

    }
}
