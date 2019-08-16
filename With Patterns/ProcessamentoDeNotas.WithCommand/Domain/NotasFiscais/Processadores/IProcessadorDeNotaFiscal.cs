using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores
{
    public interface IProcessadorDeNotaFiscal
    {
        Task ExecuteAsync();
    }
}