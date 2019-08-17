namespace Pagamentos.WithAdapter.Tefs.Factory
{
    public interface IIntegracaoComTefFactory
    {
        ITef Fabricar(short tipoDoTef);
    }
}