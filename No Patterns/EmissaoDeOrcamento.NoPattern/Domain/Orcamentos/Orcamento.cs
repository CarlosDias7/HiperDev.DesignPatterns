using EmissaoDeOrcamento.NoPattern.Domain.Base;
using EmissaoDeOrcamento.NoPattern.Domain.Clientes;
using EmissaoDeOrcamento.NoPattern.Domain.Orcamentos.Itens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmissaoDeOrcamento.NoPattern.Domain.Orcamentos
{
    public class Orcamento : Entity
    {
        public Orcamento(Cliente cliente, int codigo, ICollection<Produto> itens)
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
            Itens.Add(produto);

            SetValorTotal();
        }

        public void AddItens(ICollection<Produto> itens)
        {
            if (itens == null) throw new NullReferenceException();

            Itens = Itens ?? new List<Produto>();
            itens.ToList().ForEach(i => Itens.Add(i));

            SetValorTotal();
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