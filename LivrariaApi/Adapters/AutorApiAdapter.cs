using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using LivrariaApi.AdapterModels;
using Newtonsoft.Json;

namespace LivrariaApi.Adapters
{
    public static class AutorApiAdapter
    {
        private const string urlBase = "http://localhost:5005/AutorApi/v1";
        public static async Task<AutorModel> GetAutor(int id)
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
    }
}