using System;

namespace LoggerApi.Domain.Models
{
    public class PagamentoModel
    {
        public int NumeroPedido {get;set;}
        public DateTime DataPagamento {get;set;}
        public int IdUsuario {get;set;}
        public decimal ValorPedido {get;set;}
        public int QtdParcela {get;set;}
    }
}