using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos
{
    public class InutilizacaoDaNotaFiscal : IProcessadorDeNotaFiscal
    {
        public async Task Executa()
        {
            throw new NotImplementedException();
        }
    }
}