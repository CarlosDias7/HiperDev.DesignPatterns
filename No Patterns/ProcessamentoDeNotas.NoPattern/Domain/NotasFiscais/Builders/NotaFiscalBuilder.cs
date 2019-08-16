using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes.Tipos;

namespace ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Builders
{
    public class NotaFiscalBuilder
    {
        private string CnpjDaLoja { get; set; }
        private short Modelo { get; set; }
        private int Numero { get; set; }
        private int Serie { get; set; }
        private NaoAutorizada Situacao { get; set; }
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

        public NotaFiscalBuilder WithSerie(int serie)
        {
            Serie = serie;
            return this;
        }

        public NotaFiscalBuilder WithSituacao(NaoAutorizada situacao)
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