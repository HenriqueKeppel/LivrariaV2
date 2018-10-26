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
using LivrariaApi.TypeValues;

namespace LivrariaApi.Controllers
{
    [Route("LivrariaApi/v2/[controller]")]
    public class TransacaoController : Controller
    {
        [HttpPost]
        public async Task<bool> Post(Pedido pedido)
        {
            bool retorno = false;

            // obter dados do usuario a partir do pedido
            if (pedido.Usuario.IdUsuario == 1)
            {
                CartaoCreditoModel cartaoCredito = new CartaoCreditoModel
                {
                    Numero = "1234-1234",
                    NomeTitular = "Henrique IEC",
                    Bandeira = "Visa",
                    DateVencimento = new DateTime(2018, 20, 20),
                    CodigoSeguranca = 999   
                };

                TransacaoModel request = new TransacaoModel
                {
                    Valor = 59,
                    QtdParcelas = 1,
                    dataTransacao = DateTime.Now,
                    Cartao = cartaoCredito
                };

                retorno = TransacaoService.ExecutaTransacao(request).Result;
            }
            return retorno;
        }
    }
}