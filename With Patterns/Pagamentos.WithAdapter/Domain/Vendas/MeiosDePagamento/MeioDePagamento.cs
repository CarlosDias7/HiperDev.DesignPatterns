using Pagamentos.WithAdapter.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.WithAdapter.Domain.Vendas.MeiosDePagamento
{
    public abstract class MeioDePagamento : Entity
    {
        public MeioDePagamento(int codigo, decimal valor)
        {
        }

        public decimal Valor { get; private set; }

        public void SetValor(decimal valor)
        {
            Valor = valor;
        }
    }
}