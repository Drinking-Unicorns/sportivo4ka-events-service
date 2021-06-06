using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Base;

namespace sportivo4ka.Events.Data.Entity
{
    public class CordsEntity : Base
    {
        //Широта
        public double Lat { get; set; }

        //Долгота
        public double Lng { get; set; }

        public EventEntity Event { get; set; }

        public int EventId { get; set; }

        public double Distantion(CordsEntity cords2)
        {
            var p = Math.PI / 180;
            var a = 0.5 - Math.Cos((cords2.Lat - Lat) * p) / 2 +
                    Math.Cos(Lat * p) * Math.Cos(cords2.Lat * p) *
                    (1 - Math.Cos((cords2.Lng - Lng) * p)) / 2;

            return 12742 * Math.Asin(Math.Sqrt(a)); // 2 * R; R = 6371 km
        }

        public double Distantion(Cords cords2)
        {
            var p = Math.PI / 180;
            var a = 0.5 - Math.Cos((cords2.Lat - Lat) * p) / 2 +
                    Math.Cos(Lat * p) * Math.Cos(cords2.Lat * p) *
                    (1 - Math.Cos((cords2.Lng - Lng) * p)) / 2;

            return 12742 * Math.Asin(Math.Sqrt(a)); // 2 * R; R = 6371 km
        }
    }
}
