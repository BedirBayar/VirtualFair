using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models
{
    public class Stand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type_ID { get; set; }
        public int Owner_ID { get; set; }

    }
}
