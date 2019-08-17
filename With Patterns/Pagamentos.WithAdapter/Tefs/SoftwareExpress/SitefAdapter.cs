using Pagamentos.WithAdapter.Domain.Vendas;
using Pagamentos.WithAdapter.Domain.Vendas.MeiosDePagamento.Tipos;

namespace Pagamentos.WithAdapter.Tefs.SoftwareExpress
{
    public class SitefAdapter : ITef
    {
        private readonly Sitef _sitef;

        public SitefAdapter()
        {
            _sitef = new Sitef();
        }

        public void ProcessarPagamento(Venda venda, Tef tef)
        {
            Vender(tef);
            ConsultaRecibo(venda, tef);
        }

        private string ConsultaRecibo(Venda venda, Tef tef) => _sitef.ConsultaRecibo(venda.CnpjDaLoja, tef.Valor);

        private bool Vender(Tef tef) => _sitef.Vender(tef.Valor);
    }
}