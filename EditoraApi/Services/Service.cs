using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EditoraApi.Models;

namespace EditoraApi.Services
{
    public static class Service
    {
        public static async Task<List<EditoraModel>> GetEditoras()
        {
            List<EditoraModel> Editoras = new List<EditoraModel>();

            #region Mock
            EditoraModel mock1 = new EditoraModel
            {
                Id = 1,
                Nome = "Abril"
            };

            EditoraModel mock2 = new EditoraModel()
            {
                Id = 2,
                Nome = "Irmaos Vitalle"
            };

            Editoras.Add(mock1);
            Editoras.Add(mock2);

            #endregion

            return Editoras;
        }

        public static async Task<List<EditoraModel>> GetEditora(int id)
        {
            List<EditoraModel> Editoras = new List<EditoraModel>();

            #region Mock
            EditoraModel mock1 = new EditoraModel
            {
                Id = 1,
                Nome = "Abril"
            };

            EditoraModel mock2 = new EditoraModel()
            {
                Id = 2,
                Nome = "Irmaos Vitalle"
            };

            if (id == 1)
                Editoras.Add(mock1);
            else if (id == 2)
                Editoras.Add(mock2);

            #endregion
            
            return Editoras;
        }

        public static async Task<bool> Post(EditoraModel editora)
        {
            return true;
        }

        public static async Task<bool> Put(int id, EditoraModel value)
        {
            return true;
        }

        public static async Task<bool> Delete(int id)
        {
            return true;
        }
    }
}