using PrecoDoProduto.WithChain.Domain.Base;
using System;

namespace PrecoDoProduto.WithChain.Domain.Orcamentos.Itens
{
    public class Produto : Entity
    {
        public Produto(bool cancelado, int codigo, string nome, decimal quantidade, decimal valorUnitarioBruto)
        {
            SetCancelado(cancelado);
            SetCodigo(codigo);
            SetNome(nome);
            SetQuantidade(quantidade);
            SetValorUnitarioBruto(valorUnitarioBruto);
        }

        public bool Cancelado { get; private set; }
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

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new InvalidOperationException();
            Nome = nome;
        }

        public void SetQuantidade(decimal quantidade)
        {
            if (quantidade <= 0) throw new InvalidOperationException();
            Quantidade = quantidade;

            CalcularPrecoDoProduto();
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

        public override string ToString()
        {
            return $@"
            Produto {Codigo} - {Nome}
            Quantidade: {Quantidade}
            Vlr. Unit. Bruto: {ValorUnitarioBruto}
            Vlr. Desconto: {ValorDeDesconto}
            Vlr. Unit. Liquido: {ValorUnitarioLiquido}
            Vlr. Total: {ValorTotalLiquido}
            ";
        }

        private void CalcularPrecoDoProduto()
        {
            ValorUnitarioLiquido = ValorUnitarioBruto - ValorDeDesconto;
            ValorTotalLiquido = ValorUnitarioLiquido * Quantidade;
        }
    }
}