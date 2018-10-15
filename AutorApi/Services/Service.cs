using System;
using System.Collections.Generic;
using AutorApi.Models;
using System.Threading.Tasks;

namespace AutorApi.Services
{
    public static class Service
    {
        // TODO: criar injeção de depencia
        public static async Task<List<AutorModel>> GetAutores()
        {
            List<AutorModel> Autores = new List<AutorModel>();

            #region Mock
            AutorModel autor1 = new AutorModel
            {
                Id = 1,
                Nome = "Jonh",
                SobreNome = "Tolkien"
            };

            AutorModel autor2 = new AutorModel
            {
                Id = 2,
                Nome = "Bernard",
                SobreNome = "Cornwell"
            };
            #endregion

            Autores.Add(autor1);
            Autores.Add(autor2);

            return Autores;
        }

        public static async Task<List<AutorModel>> GetAutor(int id)
        {
            List<AutorModel> Autores = new List<AutorModel>();

            if (id == 1)
            {
                AutorModel autor1 = new AutorModel
                {
                    Id = 1,
                    Nome = "Jonh",
                    SobreNome = "Tolkien"
                };

                Autores.Add(autor1);
            }
            else if (id == 2)
            {
                AutorModel autor2 = new AutorModel
                {
                    Id = 2,
                    Nome = "Bernard",
                    SobreNome = "Cornwell"
                };

                Autores.Add(autor2);
            }

            return Autores;
        }

        public static async Task<bool> Post(AutorModel autor)
        {
            return true;
        }

        public static async Task<bool> Put(int id, AutorModel value)
        {
            return true;
        }

        public static async Task<bool> Delete(int id)
        {
            return true;
        }
    }
}