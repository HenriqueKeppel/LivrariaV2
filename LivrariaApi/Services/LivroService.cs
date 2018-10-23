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
        public static async Task<LivroModel> Obter(int isbn)
        {
            LivroModel livroResponse = LivroApiAdapter.Get(isbn).Result;
            
            return livroResponse;
        }

        public static async Task<List<LivroModel>> Obter()
        {
            return LivroApiAdapter.Get().Result;
        }

        public static async Task<bool> Incluir(Livro livro)
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
            
            return await LivroApiAdapter.Post(request);
        }

        public static async Task<bool> Editar(Livro livro)
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
            
            return await LivroApiAdapter.Put(request);
        }

        public static async Task<bool> Remover(int isbn)
        {
            return await LivroApiAdapter.Delete(isbn);
        }
    }
}