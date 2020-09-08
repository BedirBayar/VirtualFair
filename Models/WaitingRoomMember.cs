using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFair.Models
{
    public class WaitingRoomMember
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int WaitingRoom_ID { get; set; }
    }
}
