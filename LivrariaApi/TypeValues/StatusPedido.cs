using System;

namespace LivrariaApi.TypeValues
{
    public enum StatusPedido
    {
        Confirmado = 1,
        PreparandoEntrega = 2,
        SaiuParaEntrega = 3,
        Entregue = 4,
        FalhaNaEntrega = 5,
        Cancelado = 6
    }
}