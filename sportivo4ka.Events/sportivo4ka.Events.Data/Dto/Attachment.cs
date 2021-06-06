using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.Data.Dto
{
    public class AttachmentDto : Dates
    {
        public int AttachmentId { get; set; }

        public string FileName { get; set; }

        public long Size { get; set; }

        public string TempName { get; set; }

        public Stream Stream { get; set; }
    }
}
