using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace sportivo4ka.Events.General.Expansions
{
    public static class FileExpansions
    {
        public static byte[] GetBytes(this IFormFile file)
        {
            byte[] result;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                result = ms.ToArray();
            }
            return result;
        }
    }
}
