using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.Services.ProcessamentoDeNotasFiscais
{
    public class RetransmissaoDeNotaFiscalServices : IRetransmissaoDeNotaFiscalServices
    {
        public async Task<bool> Retransmitir()
        {
            await Task.Delay(1000);
            return true;
        }
    }
}