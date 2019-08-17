using GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Situacoes;

namespace GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Builders
{
    public class NotaFiscalBuilder : INotaFiscalBuilder
    {
        private string CnpjDaLoja { get; set; }
        private short Modelo { get; set; }
        private int Numero { get; set; }
        private string ProtocoloDeAutorizacao { get; set; }
        private string ProtocoloDeCancelamento { get; set; }
        private int Serie { get; set; }
        private SituacaoDaNota Situacao { get; set; }
        private decimal ValorTotal { get; set; }

        public NotaFiscal Build()
        {
            return new NotaFiscal(CnpjDaLoja, Modelo, Numero, Serie, Situacao, ValorTotal);
        }

        public NotaFiscalBuilder WithCnpjDaLoja(string cnpjDaLoja)
        {
            CnpjDaLoja = cnpjDaLoja;
            return this;
        }

        public NotaFiscalBuilder WithModelo(short modelo)
        {
            Modelo = modelo;
            return this;
        }

        public NotaFiscalBuilder WithNumero(int numero)
        {
            Numero = numero;
            return this;
        }

        public NotaFiscalBuilder WithProtocoloDeAutorizacao(string protocoloDeAutorizacao)
        {
            ProtocoloDeAutorizacao = protocoloDeAutorizacao;
            return this;
        }

        public NotaFiscalBuilder WithProtocoloDeCancelamento(string protocoloDeCancelamento)
        {
            ProtocoloDeCancelamento = protocoloDeCancelamento;
            return this;
        }

        public NotaFiscalBuilder WithSerie(int serie)
        {
            Serie = serie;
            return this;
        }

        public NotaFiscalBuilder WithSituacao(SituacaoDaNota situacao)
        {
            Situacao = situacao;
            return this;
        }

        public NotaFiscalBuilder WithValorTotal(decimal valorTotal)
        {
            ValorTotal = valorTotal;
            return this;
        }
    }
}