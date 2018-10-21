using System;
using System.Collections.Generic;

namespace LivrariaApi.AdapterModels
{
    public class AutorResponseGet
    {
        public int IndicadorErro {get;set;}
        public string Erro {get;set;}
        public List<AutorModel> Autores {get;set;}

        public AutorResponseGet()
        {
            IndicadorErro = 0;
            Erro = string.Empty;
            Autores = new List<AutorModel>();
        }
    }
}