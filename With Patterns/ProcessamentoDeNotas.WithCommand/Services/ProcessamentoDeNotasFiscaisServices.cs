using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Services
{
    public class ProcessamentoDeNotasFiscaisServices : IProcessamentoDeNotasFiscaisServices
    {
        private readonly IProcessadorDaNotaFiscalFactory _processadorDaNotaFiscalFactory;

        public ProcessamentoDeNotasFiscaisServices(IProcessadorDaNotaFiscalFactory processadorDaNotaFiscalFactory)
        {
            _processadorDaNotaFiscalFactory = processadorDaNotaFiscalFactory;
        }

        public async Task ProcessarNotas(ICollection<NotaFiscal> notasFiscais)
        {
            if (!notasFiscais?.Any(n => n.Situacao.PrecisaDeProcessamento()) ?? true) return;

            var notasEmProcessaento = notasFiscais
                .Where(n => n.Situacao.PrecisaDeProcessamento())
                .Select(n => GetActionDeProcessamento(n))
                .ToList();

            await Task.WhenAll(notasEmProcessaento);
        }

        private Task GetActionDeProcessamento(NotaFiscal notaFiscal)
        {
            var processador = _processadorDaNotaFiscalFactory.Fabricar(notaFiscal);
            return processador?.ExecuteAsync();
        }
    }
}