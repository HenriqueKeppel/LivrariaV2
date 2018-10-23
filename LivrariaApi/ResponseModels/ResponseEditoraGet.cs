using System;
using System.Collections.Generic;
using LivrariaApi.Models;

namespace LivrariaApi.ResponseModels
{
    public class ResponseEditoraGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<Editora> Editoras {get;set;}

        public ResponseEditoraGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Editoras = new List<Editora>();
        }
    }
}