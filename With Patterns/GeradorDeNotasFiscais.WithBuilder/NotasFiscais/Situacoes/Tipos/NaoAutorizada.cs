using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Situacoes.Tipos
{
    public class NaoAutorizada : SituacaoDaNota
    {
        public override bool PrecisaDeProcessamento() => true;
    }
}