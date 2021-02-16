﻿using ADProject.JsonObjects;
using ADProject.Models;
using ADProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ADProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mUserController : ControllerBase
    {
        private readonly ADProjContext _context;
        private readonly IUserService _usersService;

        public mUserController(ADProjContext context, IUserService userService)
        {
            _context = context;
            _usersService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUserById(int id)
        {
            var user = await _usersService.GetUserById(id);

            Debug.WriteLine(user.FirstName);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        [Route("userallergen/{id}")]
        public async Task<List<UserAllergen>> getUserAllergen(int id)
        {
            return await _usersService.getUserAllergens(id);
        }

        [HttpPost]
        [Route("saveuserrecipelist")]
        public async Task<booleanJson> SaveRecipe([FromBody] SaveUserRecipe saveUserRecipe)
        {
            booleanJson isSaved = new booleanJson();
            isSaved.flag = await _usersService.SaveRecipe(saveUserRecipe);
            return isSaved;
        }

        [HttpPost]
        [Route("validateuser")]
        public async Task<ApplicationUser> ValidateUser([FromBody] UserValidatorJson userJson)
        {
            ApplicationUser user = await _usersService.ValidateUser(userJson);

            return user;
        }

    }
}
