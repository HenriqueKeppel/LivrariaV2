using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaApi.ResponseModels;
using LivrariaApi.Services;

namespace LivrariaApi.Controllers
{
    [Route("LivrariaApi/v2/[controller]")]
    public class LivrosController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public async Task<ResponseLivroGet> Get(int isbn)
        {
            ResponseLivroGet result = new ResponseLivroGet();

            var retorno = await LivroService.GetLivro(isbn);

            if (retorno != null)
            {
                result.Livros.Add(retorno);
            }

            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
