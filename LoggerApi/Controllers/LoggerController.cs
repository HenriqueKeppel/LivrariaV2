using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggerApi.Domain.Models;
using LoggerApi.Domain.PostObjects;

namespace LoggerApi.Controllers
{
    [Route("LoggerApi/v1/[controller]")]
    public class LoggerController : Controller
    {
        [HttpPost("Pagamento")]
        public async Task<LoggerPost> Post([FromBody]PagamentoModel request)
        {
            LoggerPost result = new LoggerPost(200);
            return result;
        }
    }
}
