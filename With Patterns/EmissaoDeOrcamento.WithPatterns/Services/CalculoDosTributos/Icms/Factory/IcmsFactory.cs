using EmissaoDeOrcamento.WithPatterns.CrossCutting.Constants;
using EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Tipos;

namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Factory
{
    public class IcmsFactory : IIcmsFactory
    {
        public IIcms CreateByCodigo(short codigo)
        {
            switch (codigo)
            {
                case IcmsConstants.CodigoTributadoIntegralmente:
                    return new TributadoIntegralmente();

                case IcmsConstants.CodigoTributadaEComCobrancaDoIcmsPorSubstituicaoTributaria:
                    return new TributadaEComCobrancaDoIcmsPorSubstituicaoTributaria();

                case IcmsConstants.CodigoTributadoComReducaoNaBC:
                    return new TributadoComReducaoNaBC();

                case IcmsConstants.CodigoIsenta:
                    return new Isenta();

                case IcmsConstants.CodigoDiferimento:
                    return new Diferimento();

                case IcmsConstants.CodigoTributadoAnteriormenteporIcmsSt:
                    return new TributadoAnteriormenteporIcmsSt();

                case IcmsConstants.CodigoOutras:
                    return new Outras();

                default:
                    return null;
            }
        }
    }
}