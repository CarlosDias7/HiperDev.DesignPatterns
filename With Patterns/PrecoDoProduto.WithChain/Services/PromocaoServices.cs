using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.WithChain.Services
{
    public class PromocaoServices : IPromocaoServices
    {
        public decimal? GetPrecoDoProdutoEmPromocao(Produto produto)
        {
            if (produto == null || produto.Cancelado) return default;
            if (produto.Codigo == 1) return 10.00m;
            if (produto.Codigo == 2) return 20.00m;
            if (produto.Codigo == 3) return 30.00m;
            return default;
        }
    }
}