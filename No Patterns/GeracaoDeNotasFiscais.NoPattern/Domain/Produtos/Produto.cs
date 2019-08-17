using GeracaoDeProdutos.NoPattern.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeracaoDeProdutos.NoPattern.Domain.Produtos
{
    public class Produto : Entity
    {
        public Produto(int codigo, short codigoDaSituacaoTributariaIcms, string nome, decimal valorUnitarioBruto)
        {
            SetCodigo(codigo);
            SetCodigoDaSituacaoTributariaIcms(codigoDaSituacaoTributariaIcms);
            SetNome(nome);
            SetValorUnitarioBruto(valorUnitarioBruto);
        }

        public short CodigoDaSituacaoTributariaIcms { get; private set; }
        public string Nome { get; private set; }
        public decimal QuantidadeEmEstoque { get; private set; }
        public decimal ValorUnitarioBruto { get; private set; }

        public void SetCodigoDaSituacaoTributariaIcms(short codigoDaSituacaoTributariaIcms)
        {
            CodigoDaSituacaoTributariaIcms = codigoDaSituacaoTributariaIcms;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new InvalidOperationException();
            Nome = nome;
        }

        public void SetValorUnitarioBruto(decimal valorUnitarioBruto)
        {
            if (valorUnitarioBruto <= 0) throw new InvalidOperationException();
            ValorUnitarioBruto = valorUnitarioBruto;
        }
    }
}