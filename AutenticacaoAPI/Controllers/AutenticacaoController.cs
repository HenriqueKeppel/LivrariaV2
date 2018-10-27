using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutenticacaoAPI.ResponseModels;
using AutenticacaoAPI.RequestModels;
using AutenticacaoAPI.Models;

namespace AutenticacaoAPI.Controllers
{
    [Route("AutenticacaoApi/v1/[controller]")]
    public class AutenticacaoController : Controller
    {
        [HttpPost]
        public async Task<AutenticacaoResponsePost> Post([FromBody]AutenticacaoRequestPost request)
        {
        AutenticacaoResponsePost result = new AutenticacaoResponsePost();

            if (request.Email == "keppel@iec.com.br" && request.Password == "123456")
            {
                AutenticacaoModel autenticacaoModel = new AutenticacaoModel
                {
                    Token = "dfadsfa4567"
                };

                result.Autenticacao = autenticacaoModel;
                result.IsValid = 1;
            }
            else
                result.IsValid = 0;
            return result;
        }

        
        [HttpPost("ValidaAutenticacao")]
        public async Task<bool> ValidaAutenticacao([FromBody]ValidaAutenticacaoRequestPost request)
        {
            return true;
        }
        
    }
}
