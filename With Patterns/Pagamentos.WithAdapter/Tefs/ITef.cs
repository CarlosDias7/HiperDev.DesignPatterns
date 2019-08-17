using Pagamentos.WithAdapter.Domain.Vendas;
using Pagamentos.WithAdapter.Domain.Vendas.MeiosDePagamento.Tipos;

namespace Pagamentos.WithAdapter.Tefs
{
    public interface ITef
    {
        void ProcessarPagamento(Venda venda, Tef tef);
    }
}