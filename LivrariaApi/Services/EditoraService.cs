using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class EditoraService
    {
        public static async Task<Editora> Obter(int id)
        {
            Editora retorno = null;
            EditoraModel editoraResponse = await EditoraApiAdapter.Get(id);

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

        public static async Task<IEnumerable<Editora>> Obter()
        {
            List<Editora> retorno = null;
            
            var editoras = await EditoraApiAdapter.Get();

            if (editoras != null)
            {
                retorno = new List<Editora>();
                
                foreach (EditoraModel model in editoras)
                {
                    retorno.Add(new Editora
                    {
                        Id = model.Id,
                        Nome = model.Nome
                    });
                }
            }
            return retorno;
        }

        public static async Task<bool> Incluir(Editora editora)
        {
            EditoraModel request = new EditoraModel
            {
                Id = editora.Id,
                Nome = editora.Nome
            };

            return await EditoraApiAdapter.Post(request);
        }

        public static async Task<bool> Editar(Editora editora)
        {
            EditoraModel request = new EditoraModel
            {
                Id = editora.Id,
                Nome = editora.Nome
            };

            return await EditoraApiAdapter.Put(request);
        }

        public static async Task<bool> Remover(int id)
        {
            return await EditoraApiAdapter.Delete(id);
        }
    }
}