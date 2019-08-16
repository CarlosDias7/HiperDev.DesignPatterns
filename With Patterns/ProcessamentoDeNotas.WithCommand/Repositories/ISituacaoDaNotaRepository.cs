using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes;

namespace ProcessamentoDeNotas.WithCommand.Repositories
{
    public interface ISituacaoDaNotaRepository
    {
        T GetByType<T>() where T : SituacaoDaNota;
    }
}