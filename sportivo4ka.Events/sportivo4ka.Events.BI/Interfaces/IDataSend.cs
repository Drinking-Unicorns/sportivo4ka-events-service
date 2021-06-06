using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.BI.Interfaces
{
    public interface IDataSend
    {
        Task<string> PostFileWithStringContent((Stream Stream, string Name) file, string url, string token = null);

        Task Post(object data, string url, string token = null);

        Task<T> Post<T>(object data, string url, string token = null);
    }
}
