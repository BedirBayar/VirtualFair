using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public DateTime Time { get; set; }
        public int Sender_ID { get; set; }
        public int Receiver_ID { get; set; }
    }
}
