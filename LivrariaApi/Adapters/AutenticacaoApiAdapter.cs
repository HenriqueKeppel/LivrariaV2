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
    public static class AutenticacaoApiAdapter
    {
        private const string urlBase = "http://localhost:5008/AutenticacaoApi";

        public static async Task<AutenticacaoResponsePost> Post(RequestAutenticacaoPost request)
        {
            var uri = new Uri(string.Format("{0}/Autenticacao/", urlBase));
            AutenticacaoResponsePost retorno = null;

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(request);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PostAsync(uri, content);

                if(response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<AutenticacaoResponsePost>(responseString);
                }
            }
            return retorno;
        }

        public static async Task<bool> ValidaAutenticacao(AutenticacaoModel request)
        {
             var uri = new Uri(string.Format("{0}/ValidaAutenticacao/", urlBase));

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