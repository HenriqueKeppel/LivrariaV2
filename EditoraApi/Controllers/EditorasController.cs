using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EditoraApi.ResponseModels;
using EditoraApi.Services;
using EditoraApi.Models;

namespace EditoraApi.Controllers
{
    [Route("EditoraApi/v1/[controller]")]
    public class EditoraController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<ResponseGet> Get()
        {
            ResponseGet response = new ResponseGet();

            response.Editoras = Service.GetEditoras().Result;
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseGet> Get(int id)
        {
            ResponseGet response = new ResponseGet();

            response.Editoras = Service.GetEditora(id).Result;
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody]EditoraModel value)
        {
            return Service.Post(value).Result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody]EditoraModel value)
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
