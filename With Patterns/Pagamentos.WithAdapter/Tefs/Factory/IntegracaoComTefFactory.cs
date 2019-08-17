using Pagamentos.WithAdapter.Tefs.Linx;
using Pagamentos.WithAdapter.Tefs.SoftwareExpress;

namespace Pagamentos.WithAdapter.Tefs.Factory
{
    public class IntegracaoComTefFactory : IIntegracaoComTefFactory
    {
        public ITef Fabricar(short tipoDoTef)
        {
            if (tipoDoTef == Sitef.Id) return new SitefAdapter();
            if (tipoDoTef == LinxTef.Id) return new LinxTefAdapter();
            return null;
        }
    }
}