using System;

namespace LivrariaApi.AdapterModels
{
    public class TransacaoModel
    {
        public CartaoCreditoModel Cartao {get;set;}
        public decimal Valor {get;set;}
        public int QtdParcelas { get;set;}
        public DateTime dataTransacao {get;set;}
    }
}