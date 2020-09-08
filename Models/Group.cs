using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Leader_ID { get; set; }
    }
}
