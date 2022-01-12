using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class Pasta
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public string Basliq { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
