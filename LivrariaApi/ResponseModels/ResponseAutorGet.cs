using System;
using System.Collections.Generic;
using LivrariaApi.Models;

namespace LivrariaApi.ResponseModels
{
    public class ResponseAutorGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<Autor> Autores {get;set;}

        public ResponseAutorGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Autores = new List<Autor>();
        }
    }
}