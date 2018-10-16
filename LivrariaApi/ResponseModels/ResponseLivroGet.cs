using System;
using System.Collections.Generic;
using LivrariaApi.Models;

namespace LivrariaApi.ResponseModels
{
    public class ResponseLivroGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<Livro> Livros {get;set;}

        public ResponseLivroGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Livros = new List<Livro>();
        }
    }
}