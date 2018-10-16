using System;
using System.Collections.Generic;

namespace LivrariaApi.AdapterModels
{
    public class LivroResponseGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<LivroModel> Livros {get;set;}

        public LivroResponseGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Livros = new List<LivroModel>();
        }
    }
}