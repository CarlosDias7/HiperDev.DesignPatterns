using PrecoDoProduto.NoPattern.Domain.Orcamentos.Itens;
using PrecoDoProduto.NoPattern.Domain.PedidosDeVenda;

namespace PrecoDoProduto.NoPattern.Services
{
    public class DefinirPrecoDosProdutosDoPedidoDeVendaServices
    {
        private readonly IPromocaoServices _promocaoServices;

        public DefinirPrecoDosProdutosDoPedidoDeVendaServices(IPromocaoServices promocaoServices)
        {
            _promocaoServices = promocaoServices;
        }

        public void DefinirPrecoDosProdutosDoPedidoDeVenda(PedidoDeVenda pedidoDeVenda)
        {
        }

        private void DefinirPrecoDoProduto(Produto produto)
        {
            if (produto == null) return;

            var precoPromocionalDoProduto = _promocaoServices.GetPrecoDoProdutoEmPromocao(produto);
            if (precoPromocionalDoProduto.HasValue)
            {
                var valorDeDesconto = produto.ValorUnitarioLiquido - precoPromocionalDoProduto.Value;
                produto.SetValorDeDesconto(valorDeDesconto > 0 ? valorDeDesconto : 0);
            }
            else if (produto.Quantidade >= 3.0m)
            {
                var valorDeDesconto = produto.ValorUnitarioBruto * 0.1m;
                produto.SetValorDeDesconto(valorDeDesconto);
            }
            else if (produto.Quantidade >= 5.0m)
            {
                var valorDeDesconto = produto.ValorUnitarioBruto * 0.2m;
                produto.SetValorDeDesconto(valorDeDesconto);
            }
        }
    }
}