using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos;
using ProcessamentoDeNotas.WithCommand.Repositories;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos
{
    public class RetransmissaoDeNotaFiscal : ProcessadorDeNotaFiscal, IProcessadorDeNotaFiscal
    {
        private readonly NotaFiscal _notaFiscal;

        public RetransmissaoDeNotaFiscal(ISituacaoDaNotaRepository situacaoDaNotaRepository, NotaFiscal notaFiscal)
            : base(situacaoDaNotaRepository)
        {
            _notaFiscal = notaFiscal;
        }

        public async Task Executa()
        {
            if (!await RetransmitirNota()) return;
            _notaFiscal.RegularizarNota(_situacaoDaNotaRepository.GetByType<Regular>());
        }

        private async Task<bool> RetransmitirNota()
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