using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.BI.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace sportivo4ka.Events.BI.Services
{
    public class DataSend : IDataSend
    {
        public async Task<string> PostFileWithStringContent((Stream Stream, string Name) file, string url, string token = null)
        {
            HttpResponseMessage response = null;

            try
            {
                using (var fileStream = new StreamContent(file.Stream))
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        if (!String.IsNullOrEmpty(token))
                            fileStream.Headers.Add("Token", token);

                        fileStream.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        formData.Add(fileStream, @"""file""", file.Name);
                        response = await (new HttpClient()).PostAsync(url, formData);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Upload failed {ex.Message}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}