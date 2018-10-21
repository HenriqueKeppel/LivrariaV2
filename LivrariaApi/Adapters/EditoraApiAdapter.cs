using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using LivrariaApi.AdapterModels;
using Newtonsoft.Json;

namespace LivrariaApi.Adapters
{
    public static class EditoraApiAdapter
    {
        private const string urlBase = "http://localhost:5006/EditoraApi/v1";
        public static async Task<EditoraModel> GetEditora(int id)
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
    }
}