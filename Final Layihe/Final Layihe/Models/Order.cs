using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Layihe.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedAt { get; set; }
        public int No { get; set; }
        public double TotalPrice { get; set; }
        public int IsApprove { get; set; }
        public string ApproveNote { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
