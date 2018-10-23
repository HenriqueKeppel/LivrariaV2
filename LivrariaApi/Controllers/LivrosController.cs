using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaApi.ResponseModels;
using LivrariaApi.RequestModels;
using LivrariaApi.Models;
using LivrariaApi.Services;
using LivrariaApi.AdapterModels;

namespace LivrariaApi.Controllers
{
    [Route("LivrariaApi/v2/[controller]")]
    public class LivrosController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<ResponseLivroGet> Get()
        {
            ResponseLivroGet result = new ResponseLivroGet();

            var retorno = await LivroService.Obter();

            if (retorno != null)
            {
                foreach (LivroModel livroItem in retorno)
                {
                    Livro livro = new Livro
                    {
                        Isbn = livroItem.Isbn,
                        Titulo = livroItem.Titulo,
                        AnoLancamento = livroItem.AnoLancamento,
                        Valor = livroItem.Valor
                    };

                    // Obter a editora do livro atraves do EditoraService                
                    foreach(int editoraId in livroItem.Editoras)
                        livro.Editoras.Add(await EditoraService.Obter(editoraId));

                    foreach(int autorId in livroItem.Autores)                 
                        livro.Autores.Add(await AutorService.Obter(autorId));

                    result.Livros.Add(livro);   
                }
            }
            return result;
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public async Task<ResponseLivroGet> Get(int isbn)
        {
            ResponseLivroGet result = new ResponseLivroGet();

            var retorno = await LivroService.Obter(isbn);

            if (retorno != null)
            {
                Livro livro = new Livro
                {
                    Isbn = retorno.Isbn,
                    Titulo = retorno.Titulo,
                    AnoLancamento = retorno.AnoLancamento,
                    Valor = retorno.Valor
                };                

                // Obter a editora do livro atraves do EditoraService                
                foreach(int editoraId in retorno.Editoras)
                    livro.Editoras.Add(await EditoraService.Obter(editoraId));

                foreach(int autorId in retorno.Autores)                 
                    livro.Autores.Add(await AutorService.Obter(autorId));

                result.Livros.Add(livro);
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]RequestLivroPost request)
        {
            await LivroService.Incluir(request.livro);
        }

        // PUT api/values/5
        [HttpPut("{isbn}")]
        public async Task<bool> Put(int isbn, [FromBody]RequestLivroPost request)
        {
            if (isbn == request.livro.Isbn)
                return await LivroService.Editar(request.livro);
            else
                return false;
        }

        // DELETE api/values/5
        [HttpDelete("{isbn}")]
        public async Task Delete(int isbn)
        {
            await LivroService.Remover(isbn);
        }
    }
}
