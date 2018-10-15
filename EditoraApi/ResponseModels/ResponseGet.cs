using System;
using System.Collections.Generic;
using EditoraApi.Models;

namespace EditoraApi.ResponseModels
{
    public class ResponseGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<EditoraModel> Editoras {get;set;}

        public ResponseGet()
        {
            IndicadorErro = 0;
            Erro = String.Empty;
            Editoras = new List<EditoraModel>();
        }
    }
}