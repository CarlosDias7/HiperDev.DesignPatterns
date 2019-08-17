using System;

namespace PrecoDoProduto.WithChain.Domain.Base
{
    public abstract class Builder<TEntity> : IBuilder<TEntity>
        where TEntity : Entity
    {
        protected int Codigo { get; set; }

        public abstract TEntity Build();

        public IBuilder<TEntity> WithCodigo(int codigo)
        {
            Codigo = codigo;
            return this;
        }
    }
}