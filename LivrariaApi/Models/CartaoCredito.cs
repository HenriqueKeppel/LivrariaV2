using System;

namespace LivrariaApi.Models
{
    public class CartaoCredito
    {
        public string Numero {get;set;}
        public string NomeTitular {get;set;}
        public string Bandeira {get;set;}
        public DateTime DateVencimento {get;set;}
        public int CodigoSeguranca {get;set;}
    }
}