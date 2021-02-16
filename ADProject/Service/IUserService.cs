﻿using ADProject.JsonObjects;
using ADProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProject.Service
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserById(int? id);

        Task<List<UsersGroup>> GetUserGroupByGroupId(int? id);

        Task<List<UsersGroup>> GetUserGroupByUserId(int? id);

        Task<List<UserAllergen>> getUserAllergens(int id);

        Task<bool> JoinGroup(UsersGroup ug);


        Task<ApplicationUser> GetUserByUsername(string username);
        
        //Android
        Task<bool> SaveRecipe(SaveUserRecipe saveUserRecipe);

        Task<ApplicationUser> ValidateUser(UserValidatorJson userJson);
    }
}
