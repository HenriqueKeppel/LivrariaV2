using System;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class EditoraService
    {
        public static async Task<Editora> GetEditora(int id)
        {
            Editora retorno = null;
            EditoraModel editoraResponse = EditoraApiAdapter.GetEditora(id).Result;

            if (editoraResponse != null)
            {
                retorno = new Editora
                {
                    Id = editoraResponse.Id,
                    Nome = editoraResponse.Nome
                };
            }
            return retorno;
        }
    }
}