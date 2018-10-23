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
    public class AutorController : Controller
    {
        [HttpGet]
        public async Task<ResponseAutorGet> Get()
        {
            ResponseAutorGet result = new ResponseAutorGet();

            var retorno = await AutorService.Obter();

            result.Autores = retorno.ToList();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ResponseAutorGet> Get(int id)
        {
            ResponseAutorGet result = new ResponseAutorGet();

            var retorno = await AutorService.Obter(id);

            result.Autores.Add(retorno);

            return result;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]RequestAutorPost request)
        {
            await AutorService.Incluir(request.Autor);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody]RequestAutorPost request)
        {
            if (id == request.Autor.Id)
                return await AutorService.Editar(request.Autor);
            else
                return false;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await AutorService.Remover(id);
        }
    }
}