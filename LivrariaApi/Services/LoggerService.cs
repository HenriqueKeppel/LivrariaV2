using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LivrariaApi.Adapters;
using LivrariaApi.AdapterModels;
using LivrariaApi.Models;

namespace LivrariaApi.Services
{
    public static class LoggerService
    {
        public static async Task<bool> Incluir(PagamentoModel request)
        {
            return await LoggerApiAdapter.Post(request);
        }
    }
}