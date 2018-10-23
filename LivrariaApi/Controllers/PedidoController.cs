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
    public class PedidoController : Controller
    {
        [HttpPost]
        public async Task<ResponsePedidoPost> Post([FromBody]Carrinho carrinho)
        {
            ResponsePedidoPost response = new ResponsePedidoPost();
            Pedido pedido = new Pedido();

            // Valida autenticacao
            var usuarioAutenticado = await AutenticacaoService.ValidaAutenticacao(
                new AutenticacaoModel
                {
                    Token = carrinho.Usuario.Token
                });
            
            if (!usuarioAutenticado)
            {
                response.IndicadorErro = 1;
                response.DescricaoErro = "Usuario não autenticado!";
            }
            else
            {
                // Adiciona itens do carrinho ao pedido
                pedido.AddRangeItemPedido(carrinho.Itens);

                pedido.DataPedido = DateTime.Now;
                pedido.Status = StatusPedido.Confirmado;

                // Persistir pedido e verificar se esta ok
                if (pedido != null)
                {
                    response.NumeroPedido = pedido.NumeroPedido;
                }
            }
            return response;
        }

        // GET api/values/5
        [HttpGet("{numeroPedido}")]
        public async Task<ResponsePedidoGet> Get(int numeroPedido)
        {
            ResponsePedidoGet result = new ResponsePedidoGet();

            if (numeroPedido == 1)
            {
                Pedido pedido = new Pedido
                {
                    NumeroPedido =  1,
                    DataPedido = new DateTime(2018, 10, 10),
                    Status = StatusPedido.Confirmado,
                    QtdParcelas = 1,
                    ValorTotal = 59,
                    Usuario = new Usuario
                    {
                        IdUsuario = 1,
                        Login = "keppel@iec.com.br",
                        Token = "123456"
                    }
                };

                PedidoItem item = new PedidoItem() 
                {
                    Isbn = 1,
                    Valor = 59,
                    Titulo = "O Senhor dos Anéis - A Sociedade do Anel"
                };
                
                pedido.AddItemPedido(item);
                result.Pedidos.Add(pedido);
            }

            return result;
        }

        [HttpDelete("{numeroPdido}")]
        public async Task<bool> CancelarPedido(int numeroPdido)
        {
            // Obter pedido para cancelamento
            if (numeroPdido == 1)
                return true;
            else
                return false;
        }
    }
}