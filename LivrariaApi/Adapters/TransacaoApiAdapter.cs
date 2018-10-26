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
    public static class TransacaoApiAdapter
    {
        private const string urlBase = "http://localhost:5003/CartaoCreditoApi/v1";

        public static async Task<bool> Post(TransacaoModel request)
        {
            var uri = new Uri(string.Format("{0}/Transacao/", urlBase));

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

        public static async Task<IEnumerable<TransacaoModel>> Get(string numeroCartao, string dataTransacao)
        {
            List<TransacaoModel> responseGet = null;
            string url = string.Empty;
            
            if (!string.IsNullOrEmpty(numeroCartao) && !string.IsNullOrEmpty(dataTransacao))
                url = string.Format("?numeroCartao={0}&dataTransacao={1}", numeroCartao, dataTransacao);
            else if (!string.IsNullOrEmpty(numeroCartao))
                url = string.Format("?numeroCartao={0}", numeroCartao);
            else if (!string.IsNullOrEmpty(dataTransacao))
                url = string.Format("?dataTransacao={0}", dataTransacao);

            var uri = new Uri(string.Format("{0}/Transacao/{1}", urlBase, url));

            using (var cliente = new HttpClient())
            {
                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    responseGet = JsonConvert.DeserializeObject<List<TransacaoModel>>(responseString);
                }
            }
            return responseGet;
        }
    }
}