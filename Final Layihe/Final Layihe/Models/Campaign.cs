using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Layihe.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Text)]

        [StringLength(255)]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Desc  { get; set; }
    }
}
