using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using EmissaoDeOrcamento.WithPatterns.CrossCutting.Constants;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Tipos
{
    public class TributadoAnteriormenteporIcmsSt : Icms, IIcms
    {
        public short Codigo => IcmsConstants.CodigoTributadoAnteriormenteporIcmsSt;

        public ItemComIcmsDto Calcular(Produto produto)
        {
            var dto = GetBaseDto(produto);
            dto.BaseDeCalculoDeIcms = 0;
            dto.AliquotaDeIcms = 0;
            dto.ValorDeIcms = 0;
            dto.PercentualDeReducaoDaBaseDeCalculoDeIcmsSt = IcmsConstants.ReducaoDaBaseSt;
            dto.BaseDeCalculoDeIcmsSt = produto.ValorTotalLiquido - (produto.ValorTotalLiquido * dto.PercentualDeReducaoDaBaseDeCalculoDeIcmsSt / 100);
            dto.AliquotaDeIcmsSt = IcmsConstants.AliquotaSt;
            dto.ValorDeIcmsSt = dto.BaseDeCalculoDeIcmsSt * dto.AliquotaDeIcmsSt / 100;

            return dto;
        }
    }
}