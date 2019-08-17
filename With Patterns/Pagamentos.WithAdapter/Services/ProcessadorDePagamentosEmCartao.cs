using Pagamentos.WithAdapter.Domain.Vendas;
using Pagamentos.WithAdapter.Domain.Vendas.MeiosDePagamento.Tipos;
using Pagamentos.WithAdapter.Tefs.Factory;
using System.Linq;

namespace Pagamentos.WithAdapter.Services
{
    public class ProcessadorDePagamentosEmCartao : IProcessadorDePagamentosEmCartao
    {
        private readonly IIntegracaoComTefFactory _integracaoComTefFactory;

        public ProcessadorDePagamentosEmCartao(IIntegracaoComTefFactory integracaoComTefFactory)
        {
            _integracaoComTefFactory = integracaoComTefFactory;
        }

        public void Processar(Venda venda)
        {
            if (venda.MeiosDePagamento?.OfType<Tef>()?.Any() ?? true) return;

            foreach (var tef in venda.MeiosDePagamento.OfType<Tef>())
                ProcessarPagamento(venda, tef);
        }

        private void ProcessarPagamento(Venda venda, Tef tef)
        {
            var adapter = _integracaoComTefFactory.Fabricar(tef.TipoDoTef);
            adapter.ProcessarPagamento(venda, tef);
        }
    }
}