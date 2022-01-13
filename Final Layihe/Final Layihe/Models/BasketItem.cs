using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public Snack Snack { get; set; }
        public int SnackId { get; set; }
        public Drink Drink { get; set; }
        public int DrinkId { get; set; }
    }
}
