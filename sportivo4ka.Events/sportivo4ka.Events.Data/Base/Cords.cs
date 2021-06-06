using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.Data.Base
{
    public class Cords
    {
        //Широта
        public double Lat { get; set; }

        //Долгота
        public double Lng { get; set; }

        public bool InCords(Cords[] borders)
        {
            if ((borders[1].Lat - borders[0].Lat) * (Lng - borders[0].Lng) - (borders[1].Lng - borders[0].Lng) * (Lat - borders[0].Lat) > 0)
                return true;
            return false;
        }
    }
}
