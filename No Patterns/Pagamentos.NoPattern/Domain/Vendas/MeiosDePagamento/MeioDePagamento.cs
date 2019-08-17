using Pagamentos.WithPatterns.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagamentos.NoPattern.Domain.Vendas.MeiosDePagamento
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