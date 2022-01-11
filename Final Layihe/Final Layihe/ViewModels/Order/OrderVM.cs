using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Layihe.ViewModels.Order
{
    public class OrderVM
    {
        public Order Order { get; set; }
        public ApproveVM ApproveVM { get; set; }
    }
}
