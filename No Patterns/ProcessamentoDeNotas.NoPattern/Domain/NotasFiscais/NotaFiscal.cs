using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes;
using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes.Tipos;

namespace ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais
{
    public class NotaFiscal
    {
        public NotaFiscal(string cnpjDaLoja, short modelo, int numero, int serie, NaoAutorizada situacao, decimal valorTotal)
        {
            SetCnpjDaLoja(cnpjDaLoja);
            SetModelo(modelo);
            SetNumero(numero);
            SetSerie(serie);
            SetSituacao(situacao);
            SetValorTotal(valorTotal);
        }

        public string CnpjDaLoja { get; private set; }
        public short Modelo { get; private set; }
        public int Numero { get; private set; }
        public int Serie { get; private set; }
        public SituacaoDaNota Situacao { get; private set; }
        public decimal ValorTotal { get; private set; }

        public void AutorizarNota(Autorizada autorizada)
        {
            SetSituacao(autorizada);
        }

        public void CancelarNota(Cancelada cancelada)
        {
            SetSituacao(cancelada);
        }

        public void InutilizarNota(Inutilizada inutilizada)
        {
            SetSituacao(inutilizada);
        }

        public void RegularizarNota(Regular situacao)
        {
            SetSituacao(situacao);
        }

        public void SetCnpjDaLoja(string cnpjDaLoja)
        {
            CnpjDaLoja = cnpjDaLoja;
        }

        public void SetModelo(short modelo)
        {
            Modelo = modelo;
        }

        public void SetNumero(int numero)
        {
            Numero = numero;
        }

        public void SetSerie(int serie)
        {
            Serie = serie;
        }

        public void SetSituacao(SituacaoDaNota situacao)
        {
            Situacao = situacao;
        }

        public void SetValorTotal(decimal valorTotal)
        {
            ValorTotal = valorTotal;
        }
    }
}