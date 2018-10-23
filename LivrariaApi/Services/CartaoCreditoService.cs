using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class CartaoCreditoService
    {
        public static async Task<bool> RealizarTransacao(TransacaoModel request)
        {
            return await CartaoCreditoApiAdapter.Post(request);
        }
    }
}