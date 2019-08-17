using System;
using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.WithChain.Services.DescontosDoProduto.Tipos
{
    public class DescontoPorPromocao : DescontoDoProduto, IDescontoDoProduto
    {
        private readonly IPromocaoServices _promocaoServices;

        public DescontoPorPromocao(IPromocaoServices promocaoServices)
        {
            _promocaoServices = promocaoServices;
        }

        protected override void AplicarDesconto(Produto produto)
        {
            var precoPromocionalDoProduto = _promocaoServices.GetPrecoDoProdutoEmPromocao(produto) ?? 0;

            var valorDeDesconto = produto.ValorUnitarioLiquido - precoPromocionalDoProduto;
            produto.SetValorDeDesconto(valorDeDesconto > 0 ? valorDeDesconto : 0);
        }

        protected override bool DeveAplicarDesconto(Produto produto) => _promocaoServices.GetPrecoDoProdutoEmPromocao(produto).HasValue;
    }
}