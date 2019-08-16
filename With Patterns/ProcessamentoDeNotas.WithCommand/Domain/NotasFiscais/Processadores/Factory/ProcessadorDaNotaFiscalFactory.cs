using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos;
using ProcessamentoDeNotas.WithCommand.Repositories;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Factory
{
    public class ProcessadorDaNotaFiscalFactory : IProcessadorDaNotaFiscalFactory
    {
        private readonly ISituacaoDaNotaRepository _situacaoDaNotaRepository;

        public ProcessadorDaNotaFiscalFactory(ISituacaoDaNotaRepository situacaoDaNotaRepository)
        {
            _situacaoDaNotaRepository = situacaoDaNotaRepository;
        }

        public IProcessadorDeNotaFiscal Fabricar(NotaFiscal notaFiscal)
        {
            if (notaFiscal.Situacao is NaoAutorizada) return new RetransmissaoDeNotaFiscal(_situacaoDaNotaRepository, notaFiscal);
            if (notaFiscal.Situacao is PendenteDeCancelamento) return new CancelamentoDaNotaFiscal(_situacaoDaNotaRepository, notaFiscal);
            if (notaFiscal.Situacao is PendenteDeInutilizacao) return new InutilizacaoDaNotaFiscal(_situacaoDaNotaRepository, notaFiscal);
            return null;
        }
    }
}