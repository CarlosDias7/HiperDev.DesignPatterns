using System.Threading;

namespace Pagamentos.NoPattern.Tefs
{
    public class Sitef
    {
        public string ConsultaRecibo(string cnpjDaLoja, decimal valor)
        {
            // Realiza a consulta de recibo com Sitef
            // ...

            Thread.Sleep(1000);
            return "Recibo Sitef";
        }

        public bool Vender(decimal valor)
        {
            // Realiza o pagamento com Sitef
            // ...

            Thread.Sleep(1000);
            return true;
        }
    }
}