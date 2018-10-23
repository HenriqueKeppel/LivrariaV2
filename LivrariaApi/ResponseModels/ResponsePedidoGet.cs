using System;
using System.Collections.Generic;
using LivrariaApi.Models;

namespace LivrariaApi.ResponseModels
{
    public class ResponsePedidoGet
    {
        public List<Pedido> Pedidos { get; set; }

        public ResponsePedidoGet()
        {
            Pedidos = new List<Pedido>();
        }
    }
}