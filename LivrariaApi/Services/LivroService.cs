using System;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;
using System.Collections.Generic;

namespace LivrariaApi.Services
{
    public static class LivroService
    {
        public static async Task<LivroModel> GetLivro(int isbn)
        {
            LivroModel livroResponse = LivroApiAdapter.GetLivro(isbn).Result;
            
            return livroResponse;
        }

        public static async Task<List<LivroModel>> GetLivros()
        {
            return LivroApiAdapter.GetLivro().Result;
        }

        public static async Task<bool> PostLivro(Livro livro)
        {
            LivroModel request = new LivroModel
            {
                Isbn = livro.Isbn,
                Titulo = livro.Titulo,
                AnoLancamento = livro.AnoLancamento,
                Valor = livro.Valor
            };

            // forma basica
            foreach (Autor autor in livro.Autores)
            {
                request.Autores.Add(autor.Id);
            }

            foreach (Editora editora in livro.Editoras)
            {
                request.Editoras.Add(editora.Id);
            }
            
            return await LivroApiAdapter.PostLivro(request);
        }

        public static async Task<bool> PutLivro(Livro livro)
        {
            LivroModel request = new LivroModel
            {
                Isbn = livro.Isbn,
                Titulo = livro.Titulo,
                AnoLancamento = livro.AnoLancamento,
                Valor = livro.Valor
            };

            // forma basica
            foreach (Autor autor in livro.Autores)
            {
                request.Autores.Add(autor.Id);
            }

            foreach (Editora editora in livro.Editoras)
            {
                request.Editoras.Add(editora.Id);
            }
            
            return await LivroApiAdapter.PutLivro(request);
        }
    }
}