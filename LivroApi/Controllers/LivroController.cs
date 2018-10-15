using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivroApi.Models;
using LivroApi.ResponseModels;
using LivroApi.Services;

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

            response.Livros = Service.GetLivros().Result;
            return response;            
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public async Task<ResponseGet> Get(int isbn)
        {
            ResponseGet response = new ResponseGet();

            response.Livros = Service.GetLivro(isbn).Result;

            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody]LivroModel value)
        {
            return Service.Post(value).Result;
        }

        // PUT api/values/5
        [HttpPut("{isbn}")]
        public async Task<bool> Put(int isbn, [FromBody]LivroModel value)
        {
            return Service.Put(isbn, value).Result;
        }

        // DELETE api/values/5
        [HttpDelete("{isbn}")]
        public async Task<bool> Delete(int isbn)
        {
            return Service.Delete(isbn).Result;
        }
    }
}
