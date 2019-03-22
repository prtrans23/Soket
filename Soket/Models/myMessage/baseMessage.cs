using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soket.Models.myMessage
{
    public class baseMessage
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Type { get; set; }
        public DateTime UtcTime { get; set; }
        public DateTime ServerTime { get; set; }

    }
}
