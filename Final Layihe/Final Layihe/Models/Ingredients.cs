using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public Category CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}
