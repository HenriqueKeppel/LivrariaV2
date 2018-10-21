using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using LivrariaApi.AdapterModels;
using Newtonsoft.Json;
using System.Text;

namespace LivrariaApi.Adapters
{
    public static class LivroApiAdapter
    {
        private const string urlBase = "http://localhost:5004/LivroApi/v1";
        public static async Task<LivroModel> GetLivro(int isbn)
        {
            LivroResponseGet responseGet = null;
            LivroModel livroResultado = null;

            var uri = new Uri(string.Format("{0}/Livros/{1}", urlBase, isbn));

            using (var cliente = new HttpClient())
            {
                //var data = JsonConvert.SerializeObject(request);
                //var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    responseGet = JsonConvert.DeserializeObject<LivroResponseGet>(responseString);

                    // Se não houve erro, extrai o resultado
                    if (responseGet != null && responseGet.IndicadorErro == 0)
                    {
                        livroResultado = responseGet.Livros.FirstOrDefault();
                    }
                }
            }
            return livroResultado;
        }

        public static async Task<List<LivroModel>> GetLivro()
        {
            LivroResponseGet responseGet = null;
            List<LivroModel> listaRetorno = null;

            var uri = new Uri(string.Format("{0}/Livros/", urlBase));

            using (var cliente = new HttpClient())
            {
                //var data = JsonConvert.SerializeObject(request);
                //var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    responseGet = JsonConvert.DeserializeObject<LivroResponseGet>(responseString);

                    // Se não houve erro, extrai o resultado
                    if (responseGet != null && responseGet.IndicadorErro == 0)
                    {
                        listaRetorno = responseGet.Livros;
                    }
                }
            }
            return listaRetorno;
        }

        public static async Task<bool> PostLivro(LivroModel request)
        {
            var uri = new Uri(string.Format("{0}/Livros/", urlBase));

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(request);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PutLivro(LivroModel request)
        {
            var uri = new Uri(string.Format("{0}/Livros/{1}", urlBase, request.Isbn));

            using (var cliente = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(request);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}