using PrecoDoProduto.NoPattern.Domain.Orcamentos.Itens;
using PrecoDoProduto.NoPattern.Domain.PedidosDeVenda;
using System;
using System.Linq;

namespace PrecoDoProduto.NoPattern.Services
{
    public class DefinirPrecoDosProdutosDoPedidoDeVendaServices : IDefinirPrecoDosProdutosDoPedidoDeVendaServices
    {
        private readonly IPromocaoServices _promocaoServices;

        public DefinirPrecoDosProdutosDoPedidoDeVendaServices(IPromocaoServices promocaoServices)
        {
            _promocaoServices = promocaoServices;
        }

        public void DefinirPrecoDosProdutosDoPedidoDeVenda(PedidoDeVenda pedidoDeVenda)
        {
            if (pedidoDeVenda?.Itens is null) return;

            foreach (var produto in pedidoDeVenda.Itens)
                DefinirPrecoDoProduto(produto);
        }

        private void DefinirPrecoDoProduto(Produto produto)
        {
            if (produto is null) return;

            var precoPromocionalDoProduto = _promocaoServices.GetPrecoDoProdutoEmPromocao(produto);
            if (precoPromocionalDoProduto.HasValue)
            {
                var valorDeDesconto = produto.ValorUnitarioLiquido - precoPromocionalDoProduto.Value;
                produto.SetValorDeDesconto(valorDeDesconto > 0 ? valorDeDesconto : 0);
            }
            else if (produto.Quantidade >= 3.0m && produto.Quantidade <= 5.00m)
            {
                var valorDeDesconto = produto.ValorUnitarioBruto * 0.1m;
                produto.SetValorDeDesconto(valorDeDesconto);
            }
            else if (produto.Quantidade > 5.0m)
            {
                var valorDeDesconto = produto.ValorUnitarioBruto * 0.2m;
                produto.SetValorDeDesconto(valorDeDesconto);
            }

            Console.Write(produto.ToString());
        }
    }
}