namespace GeradorDeNotasFiscais.NoPattern.Domain.NotasFiscais.Situacoes.Tipos
{
    public class PendenteDeCancelamento : SituacaoDaNota
    {
        public override bool PrecisaDeProcessamento() => true;
    }
}