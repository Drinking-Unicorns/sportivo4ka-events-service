using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Enums;

namespace sportivo4ka.Events.Data.Entity
{
    public class Event2UserEntity : Base2
    {
        public EventEntity Event { get; set; }
        
        public int EventId { get; set; }

        public int UserId { get; set; }

        public string CodeStart { get; set; }

        public string CodeEnd { get; set; }

        public CodeType CodeType { get; set; }
    }
}
