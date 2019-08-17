using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.WithChain.Services
{
    public interface IPromocaoServices
    {
        decimal? GetPrecoDoProdutoEmPromocao(Produto produto);
    }
}