using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CartaoCreditoApi.ResponseModels;
using CartaoCreditoApi.Models;

namespace CartaoCreditoApi.Controllers
{
    [Route("CartaoCreditoApi/v1/[controller]")]
    public class TransacaoController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Transacao> Get([FromQuery]string numeroCartao, string dataTransacao)
        {
            List<Transacao> listaRetorno = new List<Transacao>();

            Transacao item = new Transacao
            {
                Cartao = new CartaoCreditoModel
                {
                    Numero = "123",
                    NomeTitular = "henrique",
                    Bandeira = "visa",
                    DateVencimento = new DateTime(2018-10-07),
                    CodigoSeguranca = 999,                    
                },
                Valor = 1000,
                QtdParcelas = 10,
                dataTransacao = new DateTime(2018-10-07)
            };

            listaRetorno.Add(item);

            return listaRetorno;
        }

        // POST api/values
        [HttpPost]
        public TransacaoResponsePost Post([FromBody]Transacao transacao)
        {
            TransacaoResponsePost response = new TransacaoResponsePost();

            if (transacao != null)
                response.StatusCode = 200;
            else
                response.StatusCode = 204;

            return response;
        }
    }
}
