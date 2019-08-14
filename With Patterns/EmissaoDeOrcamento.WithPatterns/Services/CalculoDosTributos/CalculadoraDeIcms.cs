using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;
using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using System.Collections.Generic;
using System.Linq;
using EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Factory;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos
{
    public class CalculadoraDeIcms
    {
        private readonly IIcmsFactory _icmsFactory;

        public CalculadoraDeIcms(IIcmsFactory icmsFactory)
        {
            _icmsFactory = icmsFactory;
        }

        public ICollection<ItemComIcmsDto> CalcularIcms(Orcamento orcamento)
        {
            if (orcamento.Itens?.Any() ?? true) return null;
            return orcamento.Itens
                .Select(i => CalcularIcmsDoItem(i))
                .ToList();
        }

        private ItemComIcmsDto CalcularIcmsDoItem(Produto produto)
        {
            if (produto == null) return null;
            var icms = _icmsFactory.CreateByCodigo(produto.CodigoDaSituacaoTributariaIcms);
            return icms?.Calcular(produto) ?? null;
        }
    }
}