using System;
using System.Collections.Generic;
using System.Text;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Factory
{
    public class ProcessadorDaNotaFiscalFactory : IProcessadorDaNotaFiscalFactory
    {
        public IProcessadorDeNotaFiscal Fabricar(NotaFiscal notaFiscal)
        {
            if (notaFiscal.Situacao is NaoAutorizada) return new RetransmissaoDeNotaFiscal(notaFiscal);
            if (notaFiscal.Situacao is PendenteDeCancelamento) return new CancelamentoDaNotaFiscal(notaFiscal);
        }
    }
}