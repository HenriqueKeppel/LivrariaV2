using System;
using System.Collections.Generic;
using LivroApi.Models;

namespace LivroApi.ResponseModels
{
    public class ResponseGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<LivroModel> Livros {get;set;}

        public ResponseGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Livros = new List<LivroModel>();
        }
    }
}