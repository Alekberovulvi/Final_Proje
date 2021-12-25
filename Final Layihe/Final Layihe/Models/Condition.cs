using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Basliq { get; set; }
        public Category CategoryId { get; set; }

        public List<Category> Categories { get; set; }
    }
}
