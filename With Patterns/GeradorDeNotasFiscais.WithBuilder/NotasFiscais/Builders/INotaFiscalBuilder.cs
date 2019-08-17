using GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Situacoes;

namespace GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Builders
{
    public interface INotaFiscalBuilder
    {
        NotaFiscal Build();

        NotaFiscalBuilder WithCnpjDaLoja(string cnpjDaLoja);

        NotaFiscalBuilder WithModelo(short modelo);

        NotaFiscalBuilder WithNumero(int numero);

        NotaFiscalBuilder WithProtocoloDeAutorizacao(string protocoloDeAutorizacao);

        NotaFiscalBuilder WithProtocoloDeCancelamento(string protocoloDeCancelamento);

        NotaFiscalBuilder WithSerie(int serie);

        NotaFiscalBuilder WithSituacao(SituacaoDaNota situacao);

        NotaFiscalBuilder WithValorTotal(decimal valorTotal);
    }
}