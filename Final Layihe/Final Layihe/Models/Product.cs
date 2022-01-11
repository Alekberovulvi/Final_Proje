using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Final_Layihe.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Nullable<double> DiscountPrice { get; set; }
        public bool IsFeature { get; set; }
        public bool IsArrival { get; set; }
        public bool IsMostView { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Nullable<double> ExTax { get; set; }
        [StringLength(255)]
        public string Code { get; set; }
        public int Point { get; set; }
        public bool IsAvailability { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int Count { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [NotMapped]
        public IFormFile[] ProductImagesFile { get; set; }
    }
}
