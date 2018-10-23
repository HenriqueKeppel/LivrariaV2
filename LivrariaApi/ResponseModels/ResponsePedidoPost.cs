using System;

namespace LivrariaApi.ResponseModels
{
    public class ResponsePedidoPost
    {
        public int NumeroPedido {get;set;}
        public int IndicadorErro {get;set;}
        public string DescricaoErro {get;set;}

        public ResponsePedidoPost()
        {
            IndicadorErro = 0;
            DescricaoErro = string.Empty;
        }
    }
}