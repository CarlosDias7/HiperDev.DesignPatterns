using PrecoDoProduto.NoPattern.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.NoPattern.Services
{
    public interface IPromocaoServices
    {
        decimal? GetPrecoDoProdutoEmPromocao(Produto produto);
    }
}