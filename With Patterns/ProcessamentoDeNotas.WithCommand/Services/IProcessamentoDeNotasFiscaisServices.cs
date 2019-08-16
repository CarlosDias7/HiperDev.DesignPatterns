using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Services
{
    public interface IProcessamentoDeNotasFiscaisServices
    {
        Task ProcessarNotas(ICollection<NotaFiscal> notasFiscais);
    }
}