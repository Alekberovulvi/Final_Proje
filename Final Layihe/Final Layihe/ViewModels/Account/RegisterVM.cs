using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Layihe.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Phone { get; set; }
        [EmailAddress,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [EmailAddress, DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress, DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
