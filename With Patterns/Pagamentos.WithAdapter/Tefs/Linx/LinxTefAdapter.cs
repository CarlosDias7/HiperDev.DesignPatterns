using System;
using Pagamentos.WithAdapter.Domain.Vendas;
using Pagamentos.WithAdapter.Domain.Vendas.MeiosDePagamento.Tipos;

namespace Pagamentos.WithAdapter.Tefs.Linx
{
    public class LinxTefAdapter : ITef
    {
        private readonly LinxTef _linxTef;

        public LinxTefAdapter()
        {
            _linxTef = new LinxTef();
        }

        public void ProcessarPagamento(Venda venda, Tef tef)
        {
            Vender(venda, tef);
            ConsultaRecibo(venda, tef);
        }

        private string ConsultaRecibo(Venda venda, Tef tef) => _linxTef.ConsultaRecibo(venda.CnpjDaLoja, DateTime.Now, tef.Valor);

        private bool Vender(Venda venda, Tef tef) => _linxTef.Vender(venda.CnpjDaLoja, tef.Valor);
    }
}