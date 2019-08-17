namespace Pagamentos.WithPatterns.Domain.Base
{
    public interface IBuilder<TEntity>
        where TEntity : Entity
    {
        TEntity Build();
    }
}