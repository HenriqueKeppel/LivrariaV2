using System;
using System.Collections.Generic;
using LivrariaApi.TypeValues;
using System.Linq;

namespace LivrariaApi.Models
{   
    public class Pedido
    {
        public int NumeroPedido {get; set;}
        public Decimal ValorTotal {get; set;}
        public int QtdParcelas {get;set;}
        public List<PedidoItem> ItensPedido {get; set;}
        public StatusPedido Status {get;set;}
        public DateTime DataPedido  {get;set;}
        public Usuario Usuario{get;set;}
        public CartaoCredito CartaoCredito {get;set;}
        
        public Pedido()
        {
            // TODO: gerar numero de pedido
            NumeroPedido = 1;
            ItensPedido = new List<PedidoItem>();
        }

        public void AddRangeItemPedido(List<PedidoItem> itens)
        {
            ItensPedido = itens;
            CalculaValorTotal();
        }

        public void AddItemPedido(PedidoItem item)
        {
            ItensPedido.Add(item);
            ValorTotal += item.Valor;
        }

        public void RemoveItemPedido(PedidoItem item)
        {
            ItensPedido.Remove(item);
            ValorTotal -= item.Valor;
        }        

        private void CalculaValorTotal()
        {
            ValorTotal = ItensPedido.Sum(o => o.Valor);
        }
    }
}