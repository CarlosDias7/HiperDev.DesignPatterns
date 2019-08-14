using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using EmissaoDeOrcamento.WithPatterns.CrossCutting.Constants;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Tipos
{
    public class Isenta : Icms, IIcms
    {
        public short Codigo => IcmsConstants.CodigoIsenta;

        public ItemComIcmsDto Calcular(Produto produto)
        {
            var dto = GetBaseDto(produto);
            dto.BaseDeCalculoDeIcms = 0;
            dto.AliquotaDeIcms = 0;
            dto.ValorDeIcms = 0;
            dto.BaseDeCalculoDeIcmsSt = 0;
            dto.AliquotaDeIcmsSt = 0;
            dto.ValorDeIcmsSt = 0;

            return dto;
        }
    }
}