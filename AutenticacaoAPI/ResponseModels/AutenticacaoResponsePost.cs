using System;
using AutenticacaoAPI.Models;

namespace AutenticacaoAPI.ResponseModels
{
    public class AutenticacaoResponsePost
    {
        public AutenticacaoModel Autenticacao {get;set;}
        public int IsValid {get;set;}
    }
}