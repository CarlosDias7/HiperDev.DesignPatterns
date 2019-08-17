using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.WithChain.Services.DescontosDoProduto
{
    public interface IDescontoDoProduto
    {
        void Executa(Produto produto);

        void SetProximo(IDescontoDoProduto descontoDoProduto);
    }
}