using PrecoDoProduto.WithChain.Domain.Base;
using PrecoDoProduto.WithChain.Domain.Clientes;
using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrecoDoProduto.WithChain.Domain.PedidosDeVenda
{
    public class PedidoDeVenda : Entity
    {
        public PedidoDeVenda(int codigo, Cliente cliente, ICollection<Produto> itens)
        {
            SetCliente(cliente);
            SetCodigo(codigo);

            AddItens(itens);
        }

        public Cliente Cliente { get; private set; }
        public ICollection<Produto> Itens { get; private set; }
        public decimal ValorTotal { get; private set; }

        public void AddItem(Produto produto)
        {
            if (produto == null) throw new NullReferenceException();

            Itens = Itens ?? new List<Produto>();

            if (Itens.Any(i => i.Codigo == produto.Codigo))
            {
                var produtoDaLista = Itens.First(i => i.Codigo == produto.Codigo);
                produtoDaLista.SetQuantidade(produtoDaLista.Quantidade + produto.Quantidade);
                return;
            }

            Itens.Add(produto);
            SetValorTotal();
        }

        public void AddItens(ICollection<Produto> itens)
        {
            if (itens == null) throw new NullReferenceException();

            Itens = Itens ?? new List<Produto>();
            itens.ToList().ForEach(i => AddItem(i));
        }

        public void SetCliente(Cliente cliente)
        {
            Cliente = cliente ?? throw new NullReferenceException();
        }

        private void SetValorTotal()
        {
            ValorTotal = Itens?.Where(p => !p.Cancelado).Sum(p => p.ValorTotalLiquido) ?? 0;
        }
    }
}