using System;
using System.Collections.Generic;

namespace LivrariaApi.Models
{
    public class Carrinho
    {
        public int Id { get;set; }
        public List<PedidoItem> Itens {get;set;}
        public Usuario Usuario {get;set;}

        public Carrinho(int id)
        {
            Id = id;
            Itens = new List<PedidoItem>();
        }
    }
}