using System;
using System.Collections.Generic;

namespace LivrariaApi.AdapterModels
{
    public class EditoraResponseGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<EditoraModel> Editoras {get;set;}

        public EditoraResponseGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Editoras = new List<EditoraModel>();
        }
    }
}