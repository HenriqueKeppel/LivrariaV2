using System;
using System.Collections.Generic;

namespace LivrariaApi.AdapterModels
{
    public class LivroModel
    {
        public int Isbn { get;set;  }
        public string Titulo { get;set;  }
        public List<int> Editoras { get;set;  }
        public DateTime AnoLancamento { get;set; }
        public Decimal Valor { get; set; }
        public List<int> Autores { get;set; }
        public LivroModel()
        {
            Editoras = new List<int>();
            Autores = new List<int>();
        }       
    }
}
