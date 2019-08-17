using System;
using System.Threading;

namespace Pagamentos.NoPattern.Tefs
{
    public class LinxTef
    {
        public string ConsultaRecibo(string cnpjDaLoja, DateTime data, decimal valor)
        {
            // Realiza a consulta de recibo com LinxTef
            // ...

            Thread.Sleep(1000);
            return "Recibo LinxTef";
        }

        public bool Vender(string cnpjDaLoja, decimal valor)
        {
            // Realiza o pagamento com LinxTef
            // ...

            Thread.Sleep(1000);
            return true;
        }
    }
}