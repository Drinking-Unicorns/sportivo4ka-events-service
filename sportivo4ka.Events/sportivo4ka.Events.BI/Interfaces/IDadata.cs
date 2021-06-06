using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Base;

namespace sportivo4ka.Events.BI.Interfaces
{
    public interface IDadata
    {
        Task<string> GetAddressAsync(Cords cords);

        Task<Cords> GetCoordinatesAsync(string address);

        string GetAddress(Cords cords);

        Cords GetCoordinates(string address);
    }
}
