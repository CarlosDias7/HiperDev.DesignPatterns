namespace EmissaoDeOrcamento.WithPatterns.Services.CalculoDosTributos.Icms.Factory
{
    public interface IIcmsFactory
    {
        IIcms CreateByCodigo(short codigo);
    }
}