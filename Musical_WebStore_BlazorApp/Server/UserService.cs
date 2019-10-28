using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Services
{
    public class UserService
    {
        UserManager<User> _userManager {get;}
        public void ChangeData(string email, string login, string password, string oldPassword)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            user.UserName = login;
            _userManager.ChangePasswordAsync(user, oldPassword, password);
            _userManager.UpdateAsync(user);
        }
    }
}