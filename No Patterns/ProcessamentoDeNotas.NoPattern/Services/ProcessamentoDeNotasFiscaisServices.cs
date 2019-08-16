using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais;
using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes.Tipos;
using ProcessamentoDeNotas.NoPattern.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.NoPattern.Services
{
    public class ProcessamentoDeNotasFiscaisServices : IProcessamentoDeNotasFiscaisServices
    {
        private readonly ISituacaoDaNotaRepository _situacaoDaNotaRepository;

        public ProcessamentoDeNotasFiscaisServices(ISituacaoDaNotaRepository situacaoDaNotaRepository)
        {
            _situacaoDaNotaRepository = situacaoDaNotaRepository;
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

        private async Task CancelaNotaAsync(NotaFiscal notaFiscal)
        {
            // Simulando a lógica de cancelamento de Nota
            try
            {
                await Task.Delay(1000);
                notaFiscal.CancelarNota(_situacaoDaNotaRepository.GetByType<Cancelada>());
            }
            catch
            {
            }
        }

        private Task GetActionDeProcessamento(NotaFiscal notaFiscal)
        {
            if (notaFiscal.Situacao is NaoAutorizada) return RetransmitirNotaAsync(notaFiscal);
            if (notaFiscal.Situacao is PendenteDeCancelamento) return CancelaNotaAsync(notaFiscal);
            if (notaFiscal.Situacao is PendenteDeInutilizacao) return InutilizaNotaAsync(notaFiscal);
            return null;
        }

        private async Task InutilizaNotaAsync(NotaFiscal notaFiscal)
        {
            // Simulando a lógica de inutilização de Nota
            try
            {
                await Task.Delay(1000);
                notaFiscal.InutilizarNota(_situacaoDaNotaRepository.GetByType<Inutilizada>());
            }
            catch
            {
            }
        }

        private async Task RetransmitirNotaAsync(NotaFiscal notaFiscal)
        {
            // Simulando a lógica de transmissão de Nota
            try
            {
                await Task.Delay(1000);
                notaFiscal.AutorizarNota(_situacaoDaNotaRepository.GetByType<Autorizada>());
            }
            catch
            {
            }
        }
    }
}