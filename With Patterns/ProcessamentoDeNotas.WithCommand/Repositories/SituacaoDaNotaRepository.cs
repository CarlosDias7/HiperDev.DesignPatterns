using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos;
using System.Collections.Generic;
using System.Linq;

namespace ProcessamentoDeNotas.WithCommand.Repositories
{
    public class SituacaoDaNotaRepository : ISituacaoDaNotaRepository
    {
        private readonly ICollection<SituacaoDaNota> _situacoes;

        public SituacaoDaNotaRepository()
        {
            _situacoes = new List<SituacaoDaNota>
            {
                new NaoAutorizada(),
                new PendenteDeCancelamento(),
                new PendenteDeInutilizacao(),
                new Regular()
            };
        }

        public T GetByType<T>() where T : SituacaoDaNota
            => _situacoes.OfType<T>().FirstOrDefault();
    }
}