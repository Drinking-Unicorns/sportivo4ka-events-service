using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.Data.Base
{
    public class Filter
    {
        public Cords UserCords { get; set; }

        public Cords[] ObjectCords { get; set; }

        public float MaxDistantion { get; set; }
    }
}
