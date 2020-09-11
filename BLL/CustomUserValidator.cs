using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualFair.Models;

namespace VirtualFair.BLL
{
    public class CustomUserValidator : IUserValidator<User>

    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            if (user.Email.Contains("@") && user.Email.ToLower().EndsWith(".com")) return Task.FromResult(IdentityResult.Success);
            else return Task.FromResult(IdentityResult.Failed(new IdentityError()
            {
                Code = "EmailFormatNotValid",
                Description ="Email adresinde '@' bulunmalı ve .com ile bitmelidir."
            })) ;
        }
    }
}
