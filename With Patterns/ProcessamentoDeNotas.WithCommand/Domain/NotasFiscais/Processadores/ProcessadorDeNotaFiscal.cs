using ProcessamentoDeNotas.WithCommand.Repositories;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores
{
    public abstract class ProcessadorDeNotaFiscal
    {
        protected readonly ISituacaoDaNotaRepository _situacaoDaNotaRepository;

        public ProcessadorDeNotaFiscal(ISituacaoDaNotaRepository situacaoDaNotaRepository)
        {
            _situacaoDaNotaRepository = situacaoDaNotaRepository;
        }
    }
}