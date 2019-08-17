namespace Pagamentos.NoPattern.Domain.Vendas.MeiosDePagamento.Tipos
{
    public class Tef : MeioDePagamento
    {
        public Tef(int codigo, decimal valor, short tipoDoTef) : base(codigo, valor)
        {
            SetTipoDoTef(tipoDoTef);
        }

        public short TipoDoTef { get; private set; }

        public void SetTipoDoTef(short tipoDoTef)
        {
            TipoDoTef = tipoDoTef;
        }
    }
}