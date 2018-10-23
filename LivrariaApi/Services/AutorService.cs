using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class AutorService
    {
        public static async Task<Autor> Obter(int id)
        {
            Autor retorno = null;
            AutorModel AutorResponse = await AutorApiAdapter.Get(id);

            if (AutorResponse != null)
            {
                retorno = new Autor
                {
                    Id = AutorResponse.Id,
                    Nome = AutorResponse.Nome,
                    SobreNome = AutorResponse.SobreNome
                };
            }
            return retorno;
        }

        public static async Task<IEnumerable<Autor>> Obter()
        {
            List<Autor> retorno = null;
            var AutorResponse = await AutorApiAdapter.Get();

            if (AutorResponse != null)
            {
                retorno = new List<Autor>();

                foreach (AutorModel model in AutorResponse)
                {
                    retorno.Add(new Autor{
                        Id = model.Id,
                        Nome = model.Nome,
                        SobreNome = model.SobreNome
                    });
                }
            }
            return retorno;
        }

        public static async Task<bool> Incluir(Autor autor)
        {
            AutorModel request = new AutorModel
            {
                Id = autor.Id,
                Nome = autor.Nome,
                SobreNome = autor.SobreNome
            };

            return await AutorApiAdapter.Post(request);
        }

        public static async Task<bool> Editar(Autor autor)
        {
            AutorModel request = new AutorModel
            {
                Id = autor.Id,
                Nome = autor.Nome,
                SobreNome = autor.SobreNome
            };

            return await AutorApiAdapter.Put(request);
        }

        public static async Task<bool> Remover(int id)
        {
            return await AutorApiAdapter.Delete(id);
        }
    }
}