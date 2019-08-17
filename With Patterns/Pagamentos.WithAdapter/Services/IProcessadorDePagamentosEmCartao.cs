using Pagamentos.WithAdapter.Domain.Vendas;

namespace Pagamentos.WithAdapter.Services
{
    public interface IProcessadorDePagamentosEmCartao
    {
        void Processar(Venda venda);
    }
}