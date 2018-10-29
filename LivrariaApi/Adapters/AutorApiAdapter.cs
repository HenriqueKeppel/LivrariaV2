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
    public static class AutorApiAdapter
    {
        //private const string urlBase = "http://localhost:5005/AutorApi/v1";
        private const string urlBase = "http://localhost:5008/AutorApi";
        public static async Task<AutorModel> Get(int id)
        {
            AutorResponseGet responseGet = null;
            AutorModel autorResultado = null;

            var uri = new Uri(string.Format("{0}/Autores/{1}", urlBase, id));

            using (var cliente = new HttpClient())
            {
                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    responseGet = JsonConvert.DeserializeObject<AutorResponseGet>(responseString);

                    // Se não houve erro, extrai o resultado
                    if (responseGet != null && responseGet.IndicadorErro == 0)
                    {
                        autorResultado = responseGet.Autores.FirstOrDefault();
                    }
                }
            }
            return autorResultado;
        }

        public static async Task<IEnumerable<AutorModel>> Get()
        {
            AutorResponseGet responseGet = null;
            List<AutorModel> autorResultado = null;

            var uri = new Uri(string.Format("{0}/Autores/", urlBase));

            using (var cliente = new HttpClient())
            {
                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    responseGet = JsonConvert.DeserializeObject<AutorResponseGet>(responseString);

                    // Se não houve erro, extrai o resultado
                    if (responseGet != null && responseGet.IndicadorErro == 0)
                    {
                        autorResultado = new List<AutorModel>();
                        autorResultado.AddRange(responseGet.Autores);
                    }
                }
            }
            return autorResultado;
        }

        public static async Task<bool> Post(AutorModel request)
        {
            var uri = new Uri(string.Format("{0}/Autores/", urlBase));

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

        public static async Task<bool> Put(AutorModel request)
        {
            var uri = new Uri(string.Format("{0}/Autores/{1}", urlBase, request.Id));

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(request);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.PutAsync(uri, content);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> Delete(int id)
        {
            var uri = new Uri(string.Format("{0}/Autores/{1}", urlBase, id));

            using (var cliente = new HttpClient())
            {
                HttpResponseMessage response = await cliente.DeleteAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}