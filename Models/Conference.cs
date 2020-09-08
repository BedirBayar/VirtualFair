using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models
{
    public class Conference
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Beginning{ get; set; }
        public DateTime Ending{ get; set; }
        public int Organiser_ID { get; set; }

    }
}
