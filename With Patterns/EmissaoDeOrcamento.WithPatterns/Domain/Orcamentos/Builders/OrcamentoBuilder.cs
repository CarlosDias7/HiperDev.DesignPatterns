using EmissaoDeOrcamento.WithPatterns.Domain.Base;
using EmissaoDeOrcamento.WithPatterns.Domain.Clientes;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Builders
{
    public class OrcamentoBuilder : Builder<Orcamento>
    {
        private Cliente Cliente { get; set; }

        private ICollection<Produto> Itens { get; set; }

        public override Orcamento Build()
        {
            return new Orcamento(Cliente, Codigo, Itens);
        }

        public OrcamentoBuilder WithCliente(Cliente cliente)
        {
            Cliente = cliente;
            return this;
        }

        public OrcamentoBuilder WithItens(ICollection<Produto> itens)
        {
            Itens = itens;
            return this;
        }
    }
}