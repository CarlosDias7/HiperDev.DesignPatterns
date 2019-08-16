using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos;
using ProcessamentoDeNotas.WithCommand.Repositories;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos
{
    public class RetransmissaoDeNotaFiscal : ProcessadorDeNotaFiscal, IProcessadorDeNotaFiscal
    {
        public RetransmissaoDeNotaFiscal(ISituacaoDaNotaRepository situacaoDaNotaRepository, NotaFiscal notaFiscal)
            : base(situacaoDaNotaRepository, notaFiscal)
        {
        }

        protected override string Descricao => "RETRANSMISSAO";

        public async Task ExecuteAsync()
        {
            if (!await RetransmitirNotaAsync()) return;
            _notaFiscal.AutorizarNota(_situacaoDaNotaRepository.GetByType<Autorizada>());

            EscreveNoConsole();
        }

        private async Task<bool> RetransmitirNotaAsync()
        {
            // Simulando a lógica de transmissão de Nota
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