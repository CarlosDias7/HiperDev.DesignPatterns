using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.WithChain.Services.DescontosDoProduto.Tipos
{
    public class DescontoPorQuantidadeMaiorQueCinco : DescontoDoProduto, IDescontoDoProduto
    {
        protected override void AplicarDesconto(Produto produto)
        {
            var valorDeDesconto = produto.ValorUnitarioBruto * 0.2m;
            produto.SetValorDeDesconto(valorDeDesconto);
        }

        protected override bool DeveAplicarDesconto(Produto produto) => produto.Quantidade >= 5.00m;
    }
}