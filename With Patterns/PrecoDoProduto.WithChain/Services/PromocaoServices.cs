using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;
using System.Collections.Generic;

namespace PrecoDoProduto.WithChain.Services
{
    public class PromocaoServices : IPromocaoServices
    {
        private readonly Dictionary<int, decimal> _precosPromocionaisPorCodigoDosProdutos;

        public PromocaoServices()
        {
            _precosPromocionaisPorCodigoDosProdutos = GetProdutosComPromocao();
        }

        public decimal? GetPrecoDoProdutoEmPromocao(Produto produto)
        {
            if (produto == null || produto.Cancelado) return default;
            if (_precosPromocionaisPorCodigoDosProdutos.TryGetValue(produto.Codigo, out var valor)) return valor;
            return default;
        }

        private Dictionary<int, decimal> GetProdutosComPromocao()
        {
            var precosPromocionaisPorCodigoDosProdutos = new Dictionary<int, decimal>();
            precosPromocionaisPorCodigoDosProdutos.Add(1, 10.00m);
            precosPromocionaisPorCodigoDosProdutos.Add(2, 20.00m);
            precosPromocionaisPorCodigoDosProdutos.Add(3, 30.00m);

            return precosPromocionaisPorCodigoDosProdutos;
        }
    }
}