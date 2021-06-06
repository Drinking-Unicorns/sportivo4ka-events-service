using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Base;
using sportivo4ka.Events.Data.Enums;

namespace sportivo4ka.Events.Data.Dto
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public long StartTimeLong => ((DateTimeOffset)StartTime).ToUnixTimeMilliseconds();

        public DateTime? EndTime { get; set; }

        public long? EndTimeLong => EndTime.HasValue ? ((DateTimeOffset)EndTime.Value).ToUnixTimeMilliseconds() : null;

        public IList<Tag> Tags { get; set; }

        public string Address { get; set; }

        public EventType Type { get; set; }

        public double WinningPints { get; set; }

        public string EventPhotoUrl { get; set; }
    }
}
