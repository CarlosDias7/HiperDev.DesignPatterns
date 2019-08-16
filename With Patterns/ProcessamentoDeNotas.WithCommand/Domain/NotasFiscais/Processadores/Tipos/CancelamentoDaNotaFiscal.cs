using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos;
using ProcessamentoDeNotas.WithCommand.Repositories;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos
{
    public class CancelamentoDaNotaFiscal : ProcessadorDeNotaFiscal, IProcessadorDeNotaFiscal
    {
        public CancelamentoDaNotaFiscal(ISituacaoDaNotaRepository situacaoDaNotaRepository, NotaFiscal notaFiscal)
            : base(situacaoDaNotaRepository, notaFiscal)
        {
        }

        protected override string Descricao => "CANCELAMENTO";

        public async Task ExecuteAsync()
        {
            if (!await CancelaNotaAsync()) return;
            _notaFiscal.CancelarNota(_situacaoDaNotaRepository.GetByType<Cancelada>());

            EscreveNoConsole();
        }

        private async Task<bool> CancelaNotaAsync()
        {
            // Simulando a lógica de cancelamento de Nota
            try
            {
                await Task.Delay(1000);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}