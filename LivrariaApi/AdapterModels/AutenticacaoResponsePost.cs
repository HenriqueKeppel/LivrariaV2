using System;

namespace LivrariaApi.AdapterModels
{
    public class AutenticacaoResponsePost
    {
        public AutenticacaoModel Autenticacao {get;set;}
        public int IsValid {get;set;}
    }
}
