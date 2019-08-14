using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms
{
    public interface IIcms
    {
        short Codigo { get; }

        ItemComIcmsDto Calcular(Produto produto);
    }
}