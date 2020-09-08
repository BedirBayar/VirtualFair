using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models
{
    public class Fair
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Extent { get; set; }
        public int NumberOfStant { get; set; }
        public string OuterPictureUrl { get; set; }
        public string InnerPictureUrl { get; set; }
        public int Organiser_ID { get; set; }
        public int FairType_ID { get; set; }
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
        public string Description { get; set; }

    }
}
