using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaApi.Models;

namespace LivrariaApi.Controllers
{
    [Route("LivrariaApi/v2/[controller]")]
    public class CarrinhoController : Controller
    {
        [HttpPut]
        public async Task<bool> Put(int id, [FromBody] PedidoItem item)
        {
            Carrinho carrinho = null;

            // Se o carrinho nao existe, deve ser criado. Do contrario apenas insere mais itens.
            if(id == 0)
                carrinho = new Carrinho(1);
            else
            //Recuper o carrinho na base de dados...
                carrinho = new Carrinho(id);

            carrinho.Usuario = new Usuario
            {
                IdUsuario = 1,
                Login = "keppel@iec.com.br",
                Token = "123456"
            };

            carrinho.Itens.Add(item);

            return true;
        }

        [HttpGet("{id}")]
        public async Task<Carrinho> Get(int id)
        {
            Carrinho carrinho = null;

            if (id == 1)
            {
                carrinho = new Carrinho(id);

                carrinho.Itens.Add(new PedidoItem
                {
                    Isbn = 1,
                    Valor = 59,
                    Titulo = "Senhor do Anéis - A Sociedade do Anel"
                });

                carrinho.Itens.Add(new PedidoItem
                {
                    Isbn = 2,
                    Valor = 59,
                    Titulo = "Senhor do Anéis - As Duas Torres"
                });

                carrinho.Itens.Add(new PedidoItem
                {
                    Isbn = 3,
                    Valor = 59,
                    Titulo = "Senhor do Anéis - o Retorno do Rei"
                });
            }

            return carrinho;
        }
    }
}