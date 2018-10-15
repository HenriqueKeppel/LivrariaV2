using System;
using System.Collections.Generic;
using AutorApi.Models;

namespace AutorApi.ResponseModels
{
    public class ResponseGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<AutorModel> Autores {get;set;}

        public ResponseGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Autores = new List<AutorModel>();
        }
    }
}