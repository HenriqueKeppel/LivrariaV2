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
    public class EditoraController : Controller
    {
        [HttpGet]
        public async Task<ResponseEditoraGet> Get()
        {
            ResponseEditoraGet result = new ResponseEditoraGet();

            var retorno = await EditoraService.Obter();

            result.Editoras = retorno.ToList();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ResponseEditoraGet> Get(int id)
        {
            ResponseEditoraGet result = new ResponseEditoraGet();

            var retorno = await EditoraService.Obter(id);

            result.Editoras.Add(retorno);

            return result;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]RequestEditoraPost request)
        {
            await EditoraService.Incluir(request.Editora);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody]RequestEditoraPost request)
        {
            if (id == request.Editora.Id)
                return await EditoraService.Editar(request.Editora);
            else
                return false;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await EditoraService.Remover(id);
        }
    }
}