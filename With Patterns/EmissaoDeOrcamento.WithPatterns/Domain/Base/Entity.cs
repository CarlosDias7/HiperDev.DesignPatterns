using System;

namespace EmissaoDeOrcamento.WithPatterns.Domain.Base
{
    public abstract class Entity
    {
        public int Codigo { get; private set; }

        public void SetCodigo(int codigo)
        {
            if (codigo <= 0) throw new InvalidOperationException();
            Codigo = codigo;
        }
    }
}