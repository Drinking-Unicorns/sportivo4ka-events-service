using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.Data.Dto
{
    public class SendPointDto
    {
        public int UserId { get; set; }

        public int EventId { get; set; }

        public float CountPoints { get; set; }
    }
}
