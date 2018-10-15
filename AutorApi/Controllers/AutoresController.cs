using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutorApi.Models;
using AutorApi.ResponseModels;
using AutorApi.Services;

namespace AutorApi.Controllers
{
    [Route("api/[controller]")]
    public class AutoresController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<ResponseGet> Get()
        {
            ResponseGet response = new ResponseGet();

            response.Autores = Service.GetAutores().Result;
            return response;            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ResponseGet> Get(int id)
        {
            ResponseGet response = new ResponseGet();

            response.Autores = Service.GetAutor(id).Result;

            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody]AutorModel value)
        {
            return Service.Post(value).Result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody]AutorModel value)
        {
            return Service.Put(id, value).Result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return Service.Delete(id).Result;
        }
    }
}
