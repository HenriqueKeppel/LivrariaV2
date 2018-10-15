using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivroApi.Models;
using LivroApi.ResponseModels;

namespace LivroApi.Controllers
{
    [Route("LivroApi/v1/[controller]")]
    public class LivroController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<ResponseGet> Get()
        {
            ResponseGet response = new ResponseGet();

            #region Mock
            LivroModel livroMock = new LivroModel
            {
                Isbn = 1,
                Titulo = "Senhor dos Anéis - A Sociedade do Anel",
                //public List<Guid> Editoras { get;set;  }
                AnoLancamento = new DateTime(2018, 10, 14),
                Valor = 59
                //public List<Guid> Autores 
            };

            livroMock.Editoras.Add(1);
            livroMock.Editoras.Add(2);

            livroMock.Autores.Add(1);

            LivroModel livroMock2 = new LivroModel
            {
                Isbn = 1,
                Titulo = "Senhor dos Anéis - As Duas Torres",
                AnoLancamento = new DateTime(2018, 10, 14),
                Valor = 59
            };

            livroMock2.Editoras.Add(1);
            livroMock2.Editoras.Add(2);

            livroMock2.Autores.Add(1);

            LivroModel livroMock3 = new LivroModel
            {
                Isbn = 1,
                Titulo = "Senhor dos Anéis - O Retorno do Rei",
                AnoLancamento = new DateTime(2018, 10, 14),
                Valor = 59
            };

            livroMock3.Editoras.Add(1);
            livroMock3.Editoras.Add(2);

            livroMock3.Autores.Add(1);
            #endregion

            response.Livros.Add(livroMock);
            response.Livros.Add(livroMock2);
            response.Livros.Add(livroMock3);

            return response;            
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public async Task<ResponseGet> Get(int isbn)
        {
            ResponseGet response = new ResponseGet();

            if (isbn == 1)
            {
                LivroModel livroMock = new LivroModel
                {
                    Isbn = 1,
                    Titulo = "Senhor dos Anéis - A Sociedade do Anel",
                    AnoLancamento = new DateTime(2018, 10, 14),
                    Valor = 59
                };

                livroMock.Editoras.Add(1);
                livroMock.Editoras.Add(2);

                livroMock.Autores.Add(1);

                response.Livros.Add(livroMock);
            }

            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]LivroModel value)
        {

        }

        // PUT api/values/5
        [HttpPut("{isbn}")]
        public async Task Put(int isbn, [FromBody]LivroModel value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{isbn}")]
        public async Task Delete(int isbn)
        {

        }
    }
}
