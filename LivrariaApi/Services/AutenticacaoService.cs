using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class AutenticacaoService
    {
        public static async Task<Usuario> Autenticar(RequestAutenticacaoPost request)
        {
            Usuario usuario = null;

            var response = await AutenticacaoApiAdapter.Post(request);

            if (response.IsValid == 1)
            {
                usuario = new Usuario
                {
                    IdUsuario = 1,
                    Login = request.Email,
                    Token = response.Autenticacao.Token
                };
            }
            return usuario;
        }

        public static async Task<bool> ValidaAutenticacao(AutenticacaoModel request)
        {
            return await AutenticacaoApiAdapter.ValidaAutenticacao(request);
        }
    }
}