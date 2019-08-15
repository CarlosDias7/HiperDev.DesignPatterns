using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.Services.ProcessamentoDeNotasFiscais
{
    public interface IRetransmissaoDeNotaFiscalServices
    {
        Task<bool> Retransmitir();
    }
}