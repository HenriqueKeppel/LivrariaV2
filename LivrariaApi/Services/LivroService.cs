using System;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class LivroService
    {
        public static async Task<Livro> GetLivro(int isbn)
        {
            Livro retorno = null;
            LivroModel livroResponse = LivroApiAdapter.GetLivro(isbn).Result;

            if (livroResponse != null)
            {
                retorno = new Livro
                {
                    Isbn = livroResponse.Isbn,
                    Titulo = livroResponse.Titulo,
                    AnoLancamento = livroResponse.AnoLancamento,
                    Valor = livroResponse.Valor
                };

                // TODO: obter lista de autores através do AutorApiAdapter.GetAutores
                // TODO: obter lista de editoras através do EditoraApiAdapter.GetEditoras
            }
            return retorno;
        }
    }
}