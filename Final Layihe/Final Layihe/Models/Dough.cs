using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class Dough
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string İmage { get; set; }
        public string Desc { get; set; }
        public string Basliq { get; set; }
        public string İmg { get; set; }
        public string Hood { get; set; }
        public string Description { get; set; }

        public Category CategoryId { get; set; }
        public List<Category> Categories { get; set; }

    }
}
