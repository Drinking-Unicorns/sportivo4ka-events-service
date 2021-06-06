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
using sportivo4ka.Events.General.Expansions;

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

        public async Task Post(object data, string url, string token = null) => await Post<object>(data, url, token);

        public async Task<T> Post<T>(object data, string url, string token = null)
        {
            if (String.IsNullOrEmpty(url))
                throw new Exception("Ссылка недействительна!");

            var body = data.ToJson();
            HttpResponseMessage responseMessage = null;
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent httpConent = new StringContent(body, Encoding.UTF8, "application/json");

                if (!String.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Token", token);
                responseMessage = await httpClient.PostAsync(url, httpConent);

                var json = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.StatusCode != HttpStatusCode.OK && responseMessage.StatusCode != HttpStatusCode.Created)
                    throw new Exception("Код ответа не Ok!");

                if (typeof(T) == typeof(object))
                    return default(T);

                return json.ToObject<T>();
            }
        }
    }
}