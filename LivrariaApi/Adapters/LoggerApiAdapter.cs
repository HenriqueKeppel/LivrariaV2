using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using LivrariaApi.AdapterModels;
using Newtonsoft.Json;

namespace LivrariaApi.Adapters
{
    public static class LoggerApiAdapter
    {
        private const string urlBase = "http://localhost:5001/LoggerApi/v1";

        public static async Task<bool> Post(PagamentoModel request)
        {
            var uri = new Uri(string.Format("{0}/Logger/", urlBase));

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(request);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync(uri, content);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}