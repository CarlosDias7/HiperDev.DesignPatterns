namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos
{
    public class PendenteDeInutilizacao : SituacaoDaNota
    {
        public override bool PrecisaDeProcessamento() => true;
    }
}