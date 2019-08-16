using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos;
using ProcessamentoDeNotas.WithCommand.Repositories;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos
{
    public class InutilizacaoDaNotaFiscal : ProcessadorDeNotaFiscal, IProcessadorDeNotaFiscal
    {
        public InutilizacaoDaNotaFiscal(ISituacaoDaNotaRepository situacaoDaNotaRepository, NotaFiscal notaFiscal)
            : base(situacaoDaNotaRepository, notaFiscal)
        {
        }

        protected override string Descricao => "INUTILIZACAO";

        public async Task ExecuteAsync()
        {
            if (!await InutilizaNotaAsync()) return;
            _notaFiscal.InutilizarNota(_situacaoDaNotaRepository.GetByType<Inutilizada>());

            EscreveNoConsole();
        }

        private async Task<bool> InutilizaNotaAsync()
        {
            // Simulando a lógica de inutilização de Nota
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