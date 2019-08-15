namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Factory
{
    public interface IProcessadorDaNotaFiscalFactory
    {
        IProcessadorDeNotaFiscal Fabricar(NotaFiscal notaFiscal);
    }
}