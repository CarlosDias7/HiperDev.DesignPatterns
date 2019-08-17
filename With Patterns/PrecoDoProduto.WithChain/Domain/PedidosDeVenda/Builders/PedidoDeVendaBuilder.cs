using PrecoDoProduto.WithChain.Domain.Base;
using PrecoDoProduto.WithChain.Domain.Clientes;
using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;
using System.Collections.Generic;

namespace PrecoDoProduto.WithChain.Domain.PedidosDeVenda.Builders
{
    public class PedidoDeVendaBuilder : Builder<PedidoDeVenda>
    {
        private Cliente Cliente { get; set; }

        private ICollection<Produto> Itens { get; set; }

        public override PedidoDeVenda Build()
        {
            return new PedidoDeVenda(Codigo, Cliente, Itens);
        }

        public PedidoDeVendaBuilder WithCliente(Cliente cliente)
        {
            Cliente = cliente;
            return this;
        }

        public PedidoDeVendaBuilder WithItens(ICollection<Produto> itens)
        {
            Itens = itens;
            return this;
        }
    }
}