using Pagamentos.NoPattern.Domain.Vendas;

namespace Pagamentos.NoPattern.Services
{
    public interface IProcessadorDePagamentosEmCartao
    {
        void Processar(Venda venda);
    }
}