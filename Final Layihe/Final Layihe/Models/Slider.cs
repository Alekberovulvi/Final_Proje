using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [StringLength(255)]
        public string ImageName { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile Photo { get; set; }

    }
}
