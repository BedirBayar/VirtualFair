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
            bool emailCheck = false;
            bool passwordCheck = false;
            bool nameCheck = true;

           // IdentityResult errors = new IdentityResult();

            if (user.Email.Contains("@") && user.Email.ToLower().EndsWith(".com")) emailCheck = true;
            else
            {

               return Task.FromResult( IdentityResult.Failed(new IdentityError()
                {
                    Code = "EmailFormatNotValid",
                    Description = "Email adresinde '@' bulunmalı ve .com ile bitmelidir."
                }));

            }
            if (user.Password.Length >= 7) passwordCheck = true;
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError()
                {
                    Code = "PasswordShort",
                    Description = "Parola en az 7 karakterden oluşmalıdır."
                }));
            }

            if (emailCheck && passwordCheck && nameCheck) return Task.FromResult(IdentityResult.Success);
            else return Task.FromResult(IdentityResult.Failed(new IdentityError()
            {
                Code = "UnidentifiedError",
                Description = "Bilgiler kontrol edilirken bir hata oluştu."
            }));
        }
    }
}