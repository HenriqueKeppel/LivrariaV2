using System;
using CartaoCreditoApi.Models;

namespace CartaoCreditoApi.Models
{
    public class Transacao
    {
        public CartaoCreditoModel Cartao {get;set;}
        public decimal Valor {get;set;}
        public int QtdParcelas { get;set;}
        public DateTime dataTransacao {get;set;}
    }
}