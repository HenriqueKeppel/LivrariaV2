using System;
using System.Collections.Generic;

namespace LivrariaApi.Models
{
    public class PedidoItem
    {
        public int Isbn {get;set;}
        public decimal Valor {get;set;}
        public string Titulo {get;set;}

        public PedidoItem(){}
    }
}