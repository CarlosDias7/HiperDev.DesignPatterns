using PrecoDoProduto.WithChain.Domain.PedidosDeVenda;
using PrecoDoProduto.WithChain.Services.DescontosDoProduto.Chain;

namespace PrecoDoProduto.WithChain.Services
{
    public class DefinirPrecoDosProdutosDoPedidoDeVendaServices : IDefinirPrecoDosProdutosDoPedidoDeVendaServices
    {
        private readonly IDescontoDoProdutoChain _descontoDoProdutoChain;

        public DefinirPrecoDosProdutosDoPedidoDeVendaServices(IDescontoDoProdutoChain descontoDoProdutoChain)
        {
            _descontoDoProdutoChain = descontoDoProdutoChain;
        }

        public void DefinirPrecoDosProdutosDoPedidoDeVenda(PedidoDeVenda pedidoDeVenda)
        {
            if (pedidoDeVenda?.Itens is null) return;

            foreach (var produto in pedidoDeVenda.Itens)
                _descontoDoProdutoChain.Calcular(produto);
        }
    }
}