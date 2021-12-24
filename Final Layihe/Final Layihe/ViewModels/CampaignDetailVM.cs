using Final_Layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.ViewModels
{
    public class CampaignDetailVM
    {
        public List<Brithday> Brithdays { get; set; }
        public List<Party> Parties { get; set; }
        public List<HandHeld> HandHelds { get; set; }
        public List<Cold> Colds { get; set; }
        public List<Classic> Classics { get; set; }
    }
}
