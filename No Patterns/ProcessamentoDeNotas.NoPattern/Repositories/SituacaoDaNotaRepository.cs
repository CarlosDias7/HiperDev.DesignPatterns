using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes;
using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes.Tipos;
using System.Collections.Generic;
using System.Linq;

namespace ProcessamentoDeNotas.NoPattern.Repositories
{
    public class SituacaoDaNotaRepository : ISituacaoDaNotaRepository
    {
        private readonly ICollection<SituacaoDaNota> _situacoes;

        public SituacaoDaNotaRepository()
        {
            _situacoes = new List<SituacaoDaNota>
            {
                new Autorizada(),
                new Cancelada(),
                new Inutilizada(),
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