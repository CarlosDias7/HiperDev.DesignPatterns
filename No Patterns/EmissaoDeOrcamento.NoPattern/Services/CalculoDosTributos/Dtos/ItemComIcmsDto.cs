using System;
using System.Collections.Generic;
using System.Text;

namespace EmissaoDeOrcamento.NoPattern.Services.CalculoDosTributos.Dtos
{
    public class ItemComIcmsDto
    {
        public decimal AliquotaDeIcms { get; set; }
        public decimal AliquotaDeIcmsSt { get; set; }
        public decimal BaseDeCalculoDeIcms { get; set; }
        public decimal BaseDeCalculoDeIcmsSt { get; set; }
        public int Codigo { get; set; }
        public short CodigoDaSituacaoTributariaIcms { get; set; }
        public decimal Mva { get; set; }
        public decimal PercentualDeReducaoDaBaseDeCalculo { get; set; }
        public decimal PercentualDeReducaoDaBaseDeCalculoDeIcmsSt { get; set; }
        public decimal ValorDeIcms { get; set; }
        public decimal ValorDeIcmsSt { get; set; }
        public decimal ValorDiferimento { get; set; }
    }
}