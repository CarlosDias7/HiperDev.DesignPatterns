using PrecoDoProduto.NoPattern.Domain.PedidosDeVenda;

namespace PrecoDoProduto.NoPattern.Services
{
    public interface IDefinirPrecoDosProdutosDoPedidoDeVendaServices
    {
        void DefinirPrecoDosProdutosDoPedidoDeVenda(PedidoDeVenda pedidoDeVenda);
    }
}