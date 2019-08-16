using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.NoPattern.Services
{
    public interface IProcessamentoDeNotasFiscaisServices
    {
        Task ProcessarNotas(ICollection<NotaFiscal> notasFiscais);
    }
}