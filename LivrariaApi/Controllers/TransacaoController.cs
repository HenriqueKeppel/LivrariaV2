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
                    Numero = pedido.CartaoCredito.Numero,
                    NomeTitular = pedido.CartaoCredito.NomeTitular,
                    Bandeira = pedido.CartaoCredito.Bandeira,
                    DateVencimento = pedido.CartaoCredito.DateVencimento,
                    CodigoSeguranca = pedido.CartaoCredito.CodigoSeguranca
                };

                TransacaoModel request = new TransacaoModel
                {
                    Valor = pedido.ValorTotal,
                    QtdParcelas = pedido.QtdParcelas,
                    dataTransacao = pedido.DataPedido,
                    Cartao = cartaoCredito
                };

                retorno = TransacaoService.ExecutaTransacao(request).Result;
            }
            return retorno;
        }
    }
}