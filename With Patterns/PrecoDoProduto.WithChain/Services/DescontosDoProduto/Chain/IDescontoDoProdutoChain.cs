using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.WithChain.Services.DescontosDoProduto.Chain
{
    public interface IDescontoDoProdutoChain
    {
        void Calcular(Produto produto);
    }
}