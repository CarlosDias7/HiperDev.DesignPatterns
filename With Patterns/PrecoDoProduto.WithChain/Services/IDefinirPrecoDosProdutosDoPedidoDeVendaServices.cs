using PrecoDoProduto.WithChain.Domain.PedidosDeVenda;

namespace PrecoDoProduto.WithChain.Services
{
    public interface IDefinirPrecoDosProdutosDoPedidoDeVendaServices
    {
        void DefinirPrecoDosProdutosDoPedidoDeVenda(PedidoDeVenda pedidoDeVenda);
    }
}