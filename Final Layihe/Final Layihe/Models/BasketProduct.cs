using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
