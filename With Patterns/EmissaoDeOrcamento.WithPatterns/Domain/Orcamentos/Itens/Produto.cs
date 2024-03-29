﻿using EmissaoDeOrcamento.WithPatterns.Domain.Base;
using System;

namespace EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens
{
    public class Produto : Entity
    {
        public Produto(bool cancelado, int codigo, short codigoDaSituacaoTributariaIcms, string nome, decimal quantidade, decimal valorDeDesconto,
            decimal valorUnitarioBruto)
        {
            SetCancelado(cancelado);
            SetCodigo(codigo);
            SetCodigoDaSituacaoTributariaIcms(codigoDaSituacaoTributariaIcms);
            SetNome(nome);
            SetQuantidade(quantidade);
            SetValorDeDesconto(valorDeDesconto);
            SetValorUnitarioBruto(valorUnitarioBruto);
        }

        public bool Cancelado { get; private set; }
        public short CodigoDaSituacaoTributariaIcms { get; private set; }
        public string Nome { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorDeDesconto { get; private set; }
        public decimal ValorTotalLiquido { get; private set; }
        public decimal ValorUnitarioBruto { get; private set; }
        public decimal ValorUnitarioLiquido { get; private set; }

        public void SetCancelado(bool cancelado)
        {
            Cancelado = cancelado;
        }

        public void SetCodigoDaSituacaoTributariaIcms(short codigoDaSituacaoTributariaIcms)
        {
            CodigoDaSituacaoTributariaIcms = codigoDaSituacaoTributariaIcms;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new InvalidOperationException();
            Nome = nome;
        }

        public void SetQuantidade(decimal quantidade)
        {
            if (quantidade <= 0) throw new InvalidOperationException();
            Quantidade = quantidade;
        }

        public void SetValorDeDesconto(decimal valorDeDesconto)
        {
            if (valorDeDesconto <= 0 || valorDeDesconto >= ValorUnitarioBruto) throw new InvalidOperationException();
            ValorDeDesconto = valorDeDesconto;

            CalcularPrecoDoProduto();
        }

        public void SetValorUnitarioBruto(decimal valorUnitarioBruto)
        {
            if (valorUnitarioBruto <= 0) throw new InvalidOperationException();
            ValorUnitarioBruto = valorUnitarioBruto;

            CalcularPrecoDoProduto();
        }

        private void CalcularPrecoDoProduto()
        {
            ValorUnitarioLiquido = ValorUnitarioBruto - ValorDeDesconto;
            ValorTotalLiquido = ValorUnitarioLiquido * Quantidade;
        }
    }
}