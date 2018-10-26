using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class TransacaoService
    {
        public static async Task<bool> ExecutaTransacao(TransacaoModel request)
        {
            return await TransacaoApiAdapter.Post(request);
        }
    }
}