using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.Data.Dto
{
    public class AddEventPhotoDto
    {
        public Stream Photo { get; set; }

        public string FileName { get; set; }

        public int EventId { get; set; }
    }
}
