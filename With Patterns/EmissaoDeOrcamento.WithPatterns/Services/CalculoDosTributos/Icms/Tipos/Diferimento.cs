using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using EmissaoDeOrcamento.WithPatterns.CrossCutting.Constants;
using EmissaoDeOrcamento.WithPatterns.Domain.Orcamentos.Itens;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Tipos
{
    public class Diferimento : Icms, IIcms
    {
        public short Codigo => IcmsConstants.CodigoDiferimento;

        public ItemComIcmsDto Calcular(Produto produto)
        {
            var dto = GetBaseDto(produto);
            dto.BaseDeCalculoDeIcms = produto.ValorTotalLiquido;
            dto.AliquotaDeIcms = IcmsConstants.Aliquota;
            dto.ValorDeIcms = dto.BaseDeCalculoDeIcms * dto.AliquotaDeIcms / 100;
            dto.ValorDiferimento = produto.ValorTotalLiquido * IcmsConstants.PercentualDeDiferimento / 100;

            return dto;
        }
    }
}