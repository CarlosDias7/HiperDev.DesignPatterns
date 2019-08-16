using ProcessamentoDeNotas.WithCommand.Repositories;
using System;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores
{
    public abstract class ProcessadorDeNotaFiscal
    {
        protected readonly NotaFiscal _notaFiscal;
        protected readonly ISituacaoDaNotaRepository _situacaoDaNotaRepository;

        public ProcessadorDeNotaFiscal(ISituacaoDaNotaRepository situacaoDaNotaRepository, NotaFiscal notaFiscal)
        {
            _situacaoDaNotaRepository = situacaoDaNotaRepository;
            _notaFiscal = notaFiscal;
        }

        protected abstract string Descricao { get; }

        protected void EscreveNoConsole() => Console.WriteLine($"[{Descricao}] - Nota Fiscal: Série {_notaFiscal.Serie}  Número {_notaFiscal.Numero}");
    }
}