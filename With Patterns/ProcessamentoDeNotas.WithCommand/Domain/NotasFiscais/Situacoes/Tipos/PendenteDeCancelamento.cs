using System;
using System.Collections.Generic;
using System.Text;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores;
using ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Processadores.Tipos;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos
{
    public class PendenteDeCancelamento : SituacaoDaNota
    {
        public override bool PrecisaDeProcessamento() => true;
    }
}