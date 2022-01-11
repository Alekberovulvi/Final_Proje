using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Layihe.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int No { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<double> DiscountPrice { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
