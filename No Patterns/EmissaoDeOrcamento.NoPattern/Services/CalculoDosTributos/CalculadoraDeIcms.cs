using EmissaoDeOrcamento.NoPattern.CrossCutting.Constants;
using EmissaoDeOrcamento.NoPattern.Domain.Orcamentos;
using EmissaoDeOrcamento.NoPattern.Domain.Orcamentos.Itens;
using EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos
{
    public class CalculadoraDeIcms
    {
        private enum SituacoesTributariasDeIcms : short
        {
            TributadoIntegralmente = 0,
            TributadaEComCobrançaDoIcmsPorSubstituiçãoTributaria = 10,
            TributadoComReducaoNaBC = 20,
            Isenta = 40,
            Diferimento = 51,
            TributadoAnteriormenteporIcmsSt = 60,
            Outras = 90
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

            var dto = new ItemComIcmsDto
            {
                Codigo = produto.Codigo,
                CodigoDaSituacaoTributariaIcms = produto.CodigoDaSituacaoTributariaIcms
            };

            if (produto.CodigoDaSituacaoTributariaIcms == (short)SituacoesTributariasDeIcms.TributadoIntegralmente)
            {
                dto.BaseDeCalculoDeIcms = produto.ValorTotalLiquido;
                dto.AliquotaDeIcms = IcmsConstants.Aliquota;
                dto.ValorDeIcms = dto.BaseDeCalculoDeIcms * dto.AliquotaDeIcms / 100;
            }
            else if (produto.CodigoDaSituacaoTributariaIcms == (short)SituacoesTributariasDeIcms.TributadaEComCobrançaDoIcmsPorSubstituiçãoTributaria)
            {
                dto.BaseDeCalculoDeIcms = produto.ValorTotalLiquido;
                dto.AliquotaDeIcms = IcmsConstants.Aliquota;
                dto.ValorDeIcms = dto.BaseDeCalculoDeIcms * dto.AliquotaDeIcms / 100;
                dto.Mva = IcmsConstants.Mva;
                dto.BaseDeCalculoDeIcmsSt = dto.BaseDeCalculoDeIcms + (dto.BaseDeCalculoDeIcms * dto.Mva / 100);
                dto.AliquotaDeIcmsSt = IcmsConstants.AliquotaSt;
                dto.ValorDeIcmsSt = dto.BaseDeCalculoDeIcmsSt * dto.AliquotaDeIcmsSt / 100;
                dto.ValorDeIcmsSt = dto.ValorDeIcms > dto.ValorDeIcmsSt ? 0 : dto.ValorDeIcmsSt - dto.ValorDeIcms;
            }
            else if (produto.CodigoDaSituacaoTributariaIcms == (short)SituacoesTributariasDeIcms.TributadoComReducaoNaBC)
            {
                dto.PercentualDeReducaoDaBaseDeCalculo = IcmsConstants.ReducaoDaBase;
                dto.BaseDeCalculoDeIcms = produto.ValorTotalLiquido - (produto.ValorTotalLiquido * dto.PercentualDeReducaoDaBaseDeCalculo / 100);
                dto.AliquotaDeIcms = IcmsConstants.Aliquota;
                dto.ValorDeIcms = dto.BaseDeCalculoDeIcms * dto.AliquotaDeIcms / 100;
            }
            else if (produto.CodigoDaSituacaoTributariaIcms == (short)SituacoesTributariasDeIcms.Isenta)
            {
                dto.BaseDeCalculoDeIcms = 0;
                dto.AliquotaDeIcms = 0;
                dto.ValorDeIcms = 0;
                dto.BaseDeCalculoDeIcmsSt = 0;
                dto.AliquotaDeIcmsSt = 0;
                dto.ValorDeIcmsSt = 0;
            }
            else if (produto.CodigoDaSituacaoTributariaIcms == (short)SituacoesTributariasDeIcms.Diferimento)
            {
                dto.BaseDeCalculoDeIcms = produto.ValorTotalLiquido;
                dto.AliquotaDeIcms = IcmsConstants.Aliquota;
                dto.ValorDeIcms = dto.BaseDeCalculoDeIcms * dto.AliquotaDeIcms / 100;
                dto.ValorDiferimento = produto.ValorTotalLiquido * IcmsConstants.Diferimento / 100;
            }
            else if (produto.CodigoDaSituacaoTributariaIcms == (short)SituacoesTributariasDeIcms.TributadoAnteriormenteporIcmsSt)
            {
                dto.BaseDeCalculoDeIcms = 0;
                dto.AliquotaDeIcms = 0;
                dto.ValorDeIcms = 0;
                dto.PercentualDeReducaoDaBaseDeCalculoDeIcmsSt = IcmsConstants.ReducaoDaBaseSt;
                dto.BaseDeCalculoDeIcmsSt = produto.ValorTotalLiquido - (produto.ValorTotalLiquido * dto.PercentualDeReducaoDaBaseDeCalculoDeIcmsSt / 100);
                dto.AliquotaDeIcmsSt = IcmsConstants.AliquotaSt;
                dto.ValorDeIcmsSt = dto.BaseDeCalculoDeIcmsSt * dto.AliquotaDeIcmsSt / 100;
            }
            else if (produto.CodigoDaSituacaoTributariaIcms == (short)SituacoesTributariasDeIcms.Outras)
            {
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
            }
            else
                throw new InvalidOperationException();

            return dto;
        }
    }
}