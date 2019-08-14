using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using EmissaoDeOrcamento.WithPatterns.CrossCutting.Constants;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Tipos
{
    public class TributadoComReducaoNaBC : Icms, IIcms
    {
        public short Codigo => IcmsConstants.CodigoTributadoComReducaoNaBC;

        public ItemComIcmsDto Calcular(Produto produto)
        {
            var dto = GetBaseDto(produto);

            dto.PercentualDeReducaoDaBaseDeCalculo = IcmsConstants.ReducaoDaBase;
            dto.BaseDeCalculoDeIcms = produto.ValorTotalLiquido - (produto.ValorTotalLiquido * dto.PercentualDeReducaoDaBaseDeCalculo / 100);
            dto.AliquotaDeIcms = IcmsConstants.Aliquota;
            dto.ValorDeIcms = dto.BaseDeCalculoDeIcms * dto.AliquotaDeIcms / 100;

            return dto;
        }
    }
}