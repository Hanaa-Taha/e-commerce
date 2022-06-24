﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Model
{
    public class ChangePasswordModell
    {
        //[Required(ErrorMessage ="Username is required")]
        
        //public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]

        
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm new password is required")]
        public string ConfirmNewPassword { get; set; }
    }
}
