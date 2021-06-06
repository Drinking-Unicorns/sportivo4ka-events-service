using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Base;
using sportivo4ka.Events.Data.Enums;

namespace sportivo4ka.Events.Data.ViewModels.Input
{
    public class CreateEventViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public IList<Tag> Tags { get; set; }

        public string Address { get; set; }

        public Cords Cords { get; set; }

        public EventType Type { get; set; }

        public double WinningPints { get; set; }
    }
}
