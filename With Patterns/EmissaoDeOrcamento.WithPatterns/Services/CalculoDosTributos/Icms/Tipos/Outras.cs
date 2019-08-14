using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using EmissaoDeOrcamento.WithPatterns.CrossCutting.Constants;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Tipos
{
    public class Outras : Icms, IIcms
    {
        public short Codigo => IcmsConstants.CodigoOutras;

        public ItemComIcmsDto Calcular(Produto produto)
        {
            var dto = GetBaseDto(produto);
            dto.BaseDeCalculoDeIcms = produto.ValorTotalLiquido;
            dto.AliquotaDeIcms = IcmsConstants.Aliquota;
            dto.ValorDeIcms = dto.BaseDeCalculoDeIcms * dto.AliquotaDeIcms / 100;
            dto.Mva = IcmsConstants.Mva;
            dto.PercentualDeReducaoDaBaseDeCalculoDeIcmsSt = IcmsConstants.ReducaoDaBaseSt;
            dto.BaseDeCalculoDeIcmsSt = dto.BaseDeCalculoDeIcms + (dto.BaseDeCalculoDeIcms * dto.Mva / 100);
            dto.BaseDeCalculoDeIcmsSt = dto.BaseDeCalculoDeIcmsSt - (dto.BaseDeCalculoDeIcmsSt * dto.PercentualDeReducaoDaBaseDeCalculoDeIcmsSt / 100);
            dto.AliquotaDeIcmsSt = IcmsConstants.AliquotaSt;
            dto.ValorDeIcmsSt = dto.BaseDeCalculoDeIcmsSt * dto.AliquotaDeIcmsSt / 100;
            dto.ValorDeIcmsSt = dto.ValorDeIcms > dto.ValorDeIcmsSt ? 0 : dto.ValorDeIcmsSt - dto.ValorDeIcms;

            return dto;
        }
    }
}