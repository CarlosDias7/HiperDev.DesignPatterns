using System;

namespace PrecoDoProduto.NoPattern.Domain.Base
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