using Pagamentos.NoPattern.Domain.Vendas;
using Pagamentos.NoPattern.Domain.Vendas.MeiosDePagamento.Tipos;
using Pagamentos.NoPattern.Tefs;
using System;
using System.Linq;

namespace Pagamentos.NoPattern.Services
{
    public class ProcessadorDePagamentosEmCartao : IProcessadorDePagamentosEmCartao
    {
        private const short _linxTefId = 2;
        private const short _sitefId = 1;

        public void Processar(Venda venda)
        {
            if (venda.MeiosDePagamento?.OfType<Tef>()?.Any() ?? true) return;

            foreach (var tef in venda.MeiosDePagamento.OfType<Tef>())
                ProcessarPagamento(venda, tef);
        }

        private void ProcessarPagamento(Venda venda, Tef tef)
        {
            if (tef.TipoDoTef == _sitefId)
            {
                var sitef = new Sitef();
                sitef.Vender(tef.Valor);
                sitef.ConsultaRecibo(venda.CnpjDaLoja, tef.Valor);
            }

            if (tef.TipoDoTef == _linxTefId)
            {
                var linxTef = new LinxTef();
                linxTef.Vender(venda.CnpjDaLoja, tef.Valor);
                linxTef.ConsultaRecibo(venda.CnpjDaLoja, DateTime.Now, tef.Valor);
            }
        }
    }
}