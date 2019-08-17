using Pagamentos.WithAdapter.Domain.Vendas.MeiosDePagamento;
using Pagamentos.WithAdapter.Domain.Base;
using System.Collections.Generic;
using System.Linq;

namespace Pagamentos.WithAdapter.Domain.Vendas
{
    public class Venda : Entity
    {
        public Venda(int codigo, decimal valorTotal, ICollection<MeioDePagamento> meiosDePagamento)
        {
            SetCodigo(codigo);
            SetValorTotal(valorTotal);

            AddMeiosDePagamento(meiosDePagamento);
        }

        public string CnpjDaLoja { get; private set; }
        public ICollection<MeioDePagamento> MeiosDePagamento { get; private set; }
        public decimal ValorTotal { get; private set; }

        public void AddMeioDePagamento(MeioDePagamento meioDePagamento)
        {
            if (meioDePagamento is null) return;
            MeiosDePagamento = MeiosDePagamento ?? new List<MeioDePagamento>();
            MeiosDePagamento.Add(meioDePagamento);
        }

        public void AddMeiosDePagamento(ICollection<MeioDePagamento> meiosDePagamento)
        {
            if (meiosDePagamento?.Any() ?? true) return;
            foreach (var meioDePagamento in meiosDePagamento)
                AddMeioDePagamento(meioDePagamento);
        }

        public void SetCnpjDaLoja(string cnpjDaLoja)
        {
            CnpjDaLoja = cnpjDaLoja;
        }

        public void SetValorTotal(decimal valorTotal)
        {
            ValorTotal = valorTotal;
        }
    }
}