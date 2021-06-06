using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.Data.Entity
{
    public class StatisticEntity : Base2
    {
        public int CountMembers { get; set; }

        public EventEntity Event { get; set; }

        public int EventId { get; set; }

        public int WinnerId { get; set; }
    }
}
