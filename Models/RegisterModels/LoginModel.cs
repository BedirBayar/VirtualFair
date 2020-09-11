﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models.RegisterModels
{
    public class LoginModel
    {

        [Required]
        [UIHint("Email")]
        public string Email { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
    }
}
