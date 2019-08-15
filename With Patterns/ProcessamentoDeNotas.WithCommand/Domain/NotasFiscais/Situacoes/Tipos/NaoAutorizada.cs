using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessamentoDeNotas.WithCommand.Domain.NotasFiscais.Situacoes.Tipos
{
    public class NaoAutorizada : SituacaoDaNota
    {
        public override bool PrecisaDeProcessamento() => true;
    }
}