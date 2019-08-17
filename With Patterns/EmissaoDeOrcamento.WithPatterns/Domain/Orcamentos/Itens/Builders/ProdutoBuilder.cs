using EmissaoDeOrcamento.WithPatterns.Domain.Base;

namespace EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens.Builders
{
    public class ProdutoBuilder : Builder<Produto>
    {
        private bool Cancelado { get; set; }

        private short CodigoDaSituacaoTributariaIcms { get; set; }
        private string Nome { get; set; }

        private decimal Quantidade { get; set; }

        private decimal ValorDeDesconto { get; set; }

        private decimal ValorUnitarioBruto { get; set; }

        public override Produto Build()
        {
            return new Produto(Cancelado, Codigo, CodigoDaSituacaoTributariaIcms, Nome, Quantidade, ValorDeDesconto, ValorUnitarioBruto);
        }

        public ProdutoBuilder WithCancelado(bool cancelado)
        {
            Cancelado = cancelado;
            return this;
        }

        public ProdutoBuilder WithCodigoDaSituacaoTributariaIcms(short codigoDaSituacaoTributariaIcms)
        {
            CodigoDaSituacaoTributariaIcms = codigoDaSituacaoTributariaIcms;
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

        public ProdutoBuilder WithValorDeDesconto(decimal valorDeDesconto)
        {
            ValorDeDesconto = valorDeDesconto;
            return this;
        }

        public ProdutoBuilder WithValorUnitarioBruto(decimal valorUnitarioBruto)
        {
            ValorUnitarioBruto = valorUnitarioBruto;
            return this;
        }
    }
}