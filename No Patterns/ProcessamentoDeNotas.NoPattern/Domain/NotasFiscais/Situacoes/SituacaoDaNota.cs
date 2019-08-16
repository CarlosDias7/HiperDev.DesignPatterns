namespace ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes
{
    public abstract class SituacaoDaNota
    {
        public virtual bool PrecisaDeProcessamento() => false;
    }
}