using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;
using Newtonsoft.Json;
using System.Text;

namespace LivrariaApi.Adapters
{
    public static class EditoraApiAdapter
    {
        private const string urlBase = "http://localhost:5006/EditoraApi/v1";
        public static async Task<EditoraModel> Get(int id)
        {
            EditoraResponseGet responseGet = null;
            EditoraModel editoraResultado = null;

            var uri = new Uri(string.Format("{0}/Editora/{1}", urlBase, id));

            using (var cliente = new HttpClient())
            {
                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    responseGet = JsonConvert.DeserializeObject<EditoraResponseGet>(responseString);

                    // Se não houve erro, extrai o resultado
                    if (responseGet != null && responseGet.IndicadorErro == 0)
                    {
                        editoraResultado = responseGet.Editoras.FirstOrDefault();
                    }
                }
            }
            return editoraResultado;
        }

        public static async Task<IEnumerable<EditoraModel>> Get()
        {
            EditoraResponseGet responseGet = null;
            List<EditoraModel> editoraResultado = null;

            var uri = new Uri(string.Format("{0}/Editora/", urlBase));

            using (var cliente = new HttpClient())
            {
                HttpResponseMessage response = await cliente.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    // Retornou com sucesso
                    var responseString = await response.Content.ReadAsStringAsync();
                    responseGet = JsonConvert.DeserializeObject<EditoraResponseGet>(responseString);

                    // Se não houve erro, extrai o resultado
                    if (responseGet != null && responseGet.IndicadorErro == 0)
                    {
                        editoraResultado = new List<EditoraModel>();
                        
                        foreach(EditoraModel model in responseGet.Editoras)
                            editoraResultado.Add(model);
                    }
                }
            }
            return editoraResultado;
        }

        public static async Task<bool> Post(EditoraModel request)
        {
            var uri = new Uri(string.Format("{0}/Editora/", urlBase));

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

        public static async Task<bool> Put(EditoraModel request)
        {
            var uri = new Uri(string.Format("{0}/Editora/{1}", urlBase, request.Id));

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
            var uri = new Uri(string.Format("{0}/Editora/{1}", urlBase, id));

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