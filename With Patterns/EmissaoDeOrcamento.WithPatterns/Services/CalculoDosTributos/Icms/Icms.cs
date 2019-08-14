using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms
{
    public abstract class Icms
    {
        protected ItemComIcmsDto GetBaseDto(Produto produto)
            => new ItemComIcmsDto
            {
                Codigo = produto.Codigo,
                CodigoDaSituacaoTributariaIcms = produto.CodigoDaSituacaoTributariaIcms
            };
    }
}