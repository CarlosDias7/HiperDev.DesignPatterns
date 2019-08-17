namespace GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Situacoes
{
    public abstract class SituacaoDaNota
    {
        public virtual bool PrecisaDeProcessamento() => false;
    }
}