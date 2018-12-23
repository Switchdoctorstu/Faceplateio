using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace faceplateio.Controllers
{
    public class Packet
    {
        public String from;
        public String to;
        public String packet;

      
        public Packet(String from, String to, String packet)
        {
            this.from = from;
            this.to = to;
            this.packet = packet;
        }
    }
}