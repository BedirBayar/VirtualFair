using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models
{
    public class WaitingRoom
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public int FairID { get; set; }
    }
}
