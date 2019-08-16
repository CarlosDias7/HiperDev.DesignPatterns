using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes;

namespace ProcessamentoDeNotas.NoPattern.Repositories
{
    public interface ISituacaoDaNotaRepository
    {
        T GetByType<T>() where T : SituacaoDaNota;
    }
}