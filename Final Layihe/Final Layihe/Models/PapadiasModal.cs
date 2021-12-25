using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Models
{
    public class PapadiasModal
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }

        public int PapadiasId { get; set; }

        public virtual Papadias Papadias { get; set; }

    }
}
