using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Layihe.ViewModels
{
    public class OrderVM
    {
        [Required, StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        [Required, StringLength(25)]
        public string Phone { get; set; }
        [Required, StringLength(25)]
        public string City { get; set; }
        public List<BasketVM> BasketVMs { get; set; }
    }
}
