using System.Threading;

namespace Pagamentos.WithAdapter.Tefs.SoftwareExpress
{
    public class Sitef
    {
        public static short Id = 1;

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