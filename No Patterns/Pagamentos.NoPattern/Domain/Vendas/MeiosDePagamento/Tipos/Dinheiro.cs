namespace Pagamentos.NoPattern.Domain.Vendas.MeiosDePagamento.Tipos
{
    public class Dinheiro : MeioDePagamento
    {
        public Dinheiro(int codigo, decimal valor) : base(codigo, valor)
        {
        }
    }
}