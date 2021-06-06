using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Dto;

namespace sportivo4ka.Events.Data.Returns
{
    public class EventReturn : BaseReturn
    {
        public EventDto Event { get; set; }
    }
}
