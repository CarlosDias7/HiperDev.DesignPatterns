using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;

namespace PrecoDoProduto.WithChain.Services.DescontosDoProduto
{
    public abstract class DescontoDoProduto
    {
        public IDescontoDoProduto Proximo { get; private set; }

        public void Executa(Produto produto)
        {
            if (!DeveAplicarDesconto(produto))
            {
                Proximo?.Executa(produto);
                return;
            }

            AplicarDesconto(produto);
        }

        public void SetProximo(IDescontoDoProduto descontoDoProduto) => Proximo = descontoDoProduto;

        protected abstract void AplicarDesconto(Produto produto);

        protected abstract bool DeveAplicarDesconto(Produto produto);
    }
}