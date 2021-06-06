using System;
using System.Collections.Generic;
using System.Text;
using sportivo4ka.Events.Data.Enums;
using sportivo4ka.Events.Data.Base;

namespace sportivo4ka.Events.Data.Entity
{
    public class EventEntity : Base
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Address { get; set; }

        public IList<Tag> Tags { get; set; }

        public CordsEntity Cords { get; set; }

        public EventType Type { get; set; }

        public double WinningPoints { get; set; }

        public string EventPhotoUrl { get; set; }
    }
}
