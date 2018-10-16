using System;
using System.Collections.Generic;

namespace LivrariaApi.Models
{
    public class Livro
    {
        public int Isbn { get;set;  }
        public string Titulo { get;set;  }
        public List<Editora> Editoras { get;set;  }
        public List<Autor> Autores { get;set; }
        public DateTime AnoLancamento { get;set; }
        public Decimal Valor { get; set; }

        public Livro()
        {
            Autores = new List<Autor>();
            Editoras = new List<Editora>();
        }
    }
}
