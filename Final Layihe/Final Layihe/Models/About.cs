using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class About
    {
        public int Id { get; set; }
       
        public string Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Decs { get; set; }

        public Category Category { get; set; }
        public int? CategoryId { get; set; }

    }
}
