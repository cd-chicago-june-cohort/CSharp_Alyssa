using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace bankAccounts.Models
{
    public class LoginViewModel : BaseEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password { get; set; }
    }
}