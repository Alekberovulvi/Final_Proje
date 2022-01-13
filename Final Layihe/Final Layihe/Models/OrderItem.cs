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
        [Required, StringLength(100)]
        public string ProductName { get; set; }
        [Required, Column(TypeName = "decimal(9,2)")]
        public double ProductPrice { get; set; }
        public int Count { get; set; }
        public Snack Snack { get; set; }
        public int? SnackId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
