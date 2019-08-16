namespace PrecoDoProduto.NoPattern.Domain.Base
{
    public interface IBuilder<TEntity>
        where TEntity : Entity
    {
        TEntity Build();
    }
}