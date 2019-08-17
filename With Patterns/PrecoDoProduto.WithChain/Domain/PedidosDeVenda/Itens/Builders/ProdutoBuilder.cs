using PrecoDoProduto.WithChain.Domain.Base;

namespace PrecoDoProduto.WithChain.Domain.Orcamentos.Itens.Builders
{
    public class ProdutoBuilder : Builder<Produto>
    {
        private bool Cancelado { get; set; }

        private string Nome { get; set; }

        private decimal Quantidade { get; set; }

        private decimal ValorUnitarioBruto { get; set; }

        public override Produto Build()
        {
            return new Produto(Cancelado, Codigo, Nome, Quantidade, ValorUnitarioBruto);
        }

        public ProdutoBuilder WithCancelado(bool cancelado)
        {
            Cancelado = cancelado;
            return this;
        }

        public ProdutoBuilder WithNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public ProdutoBuilder WithQuantidade(decimal quantidade)
        {
            Quantidade = quantidade;
            return this;
        }

        public ProdutoBuilder WithValorUnitarioBruto(decimal valorUnitarioBruto)
        {
            ValorUnitarioBruto = valorUnitarioBruto;
            return this;
        }
    }
}