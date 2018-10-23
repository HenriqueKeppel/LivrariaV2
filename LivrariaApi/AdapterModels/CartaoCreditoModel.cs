using System;

namespace LivrariaApi.AdapterModels
{
    public class CartaoCreditoModel
    {
        public string Numero {get;set;}
        public string NomeTitular {get;set;}
        public string Bandeira {get;set;}
        public DateTime DateVencimento {get;set;}
        public int CodigoSeguranca {get;set;}
    }
}