using System;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class AutorService
    {
        public static async Task<Autor> GetAutor(int id)
        {
            Autor retorno = null;
            AutorModel AutorResponse = AutorApiAdapter.GetAutor(id).Result;

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
    }
}