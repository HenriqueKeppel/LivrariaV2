using System;
using System.Collections.Generic;
using LivroApi.Models;
using System.Threading.Tasks;

namespace LivroApi.Services
{
    public static class Service
    {
        // TODO: criar injeção de depencia
        public static async Task<List<LivroModel>> GetLivros()
        {
            List<LivroModel> Livros = new List<LivroModel>();

            #region Mock
            LivroModel livroMock = new LivroModel
            {
                Isbn = 1,
                Titulo = "Senhor dos Anéis - A Sociedade do Anel",
                //public List<Guid> Editoras { get;set;  }
                AnoLancamento = new DateTime(2018, 10, 14),
                Valor = 59
                //public List<Guid> Autores 
            };

            livroMock.Editoras.Add(1);
            livroMock.Editoras.Add(2);

            livroMock.Autores.Add(1);

            LivroModel livroMock2 = new LivroModel
            {
                Isbn = 2,
                Titulo = "Senhor dos Anéis - As Duas Torres",
                AnoLancamento = new DateTime(2018, 10, 14),
                Valor = 59
            };

            livroMock2.Editoras.Add(1);
            livroMock2.Editoras.Add(2);

            livroMock2.Autores.Add(1);

            LivroModel livroMock3 = new LivroModel
            {
                Isbn = 3,
                Titulo = "Senhor dos Anéis - O Retorno do Rei",
                AnoLancamento = new DateTime(2018, 10, 14),
                Valor = 59
            };

            livroMock3.Editoras.Add(1);
            livroMock3.Editoras.Add(2);

            livroMock3.Autores.Add(1);
            #endregion

            Livros.Add(livroMock);
            Livros.Add(livroMock2);
            Livros.Add(livroMock3);

            return Livros;
        }

        public static async Task<List<LivroModel>> GetLivro(int isbn)
        {
            List<LivroModel> Livros = new List<LivroModel>();

            if (isbn == 1)
            {
                LivroModel livroMock = new LivroModel
                {
                    Isbn = 1,
                    Titulo = "Senhor dos Anéis - A Sociedade do Anel",
                    AnoLancamento = new DateTime(2018, 10, 14),
                    Valor = 59
                };

                livroMock.Editoras.Add(1);
                livroMock.Editoras.Add(2);

                livroMock.Autores.Add(1);

                Livros.Add(livroMock);
            }

            return Livros;
        }

        public static async Task<bool> Post(LivroModel livro)
        {
            return true;
        }

        public static async Task<bool> Put(int isbn, LivroModel value)
        {
            return true;
        }

        public static async Task<bool> Delete(int isbn)
        {
            return true;
        }
    }
}