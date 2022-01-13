using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Final_Layihe.Models;

namespace Final_Layihe.ViewModels
{
    public class BasketVM
    {
        public int? ProductId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
