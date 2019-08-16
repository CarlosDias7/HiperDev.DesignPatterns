using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais;
using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Builders;
using ProcessamentoDeNotas.NoPattern.Domain.NotasFiscais.Situacoes.Tipos;
using ProcessamentoDeNotas.NoPattern.Repositories;
using ProcessamentoDeNotas.NoPattern.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessamentoDeNotas.NoPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instancia das Notas
            ISituacaoDaNotaRepository situacaoDaNotaRerpository = new SituacaoDaNotaRepository();
            var notasParaProcessar = GetNotas(situacaoDaNotaRerpository);

            // Instacia da classe que controla o processamento
            IProcessamentoDeNotasFiscaisServices processamentoDeNotasFiscaisServices = new ProcessamentoDeNotasFiscaisServices(situacaoDaNotaRerpository);

            // Retransmissão
            Task.WaitAll(processamentoDeNotasFiscaisServices.ProcessarNotas(notasParaProcessar));

            // Cancelar notas
            CancelarNotas(situacaoDaNotaRerpository, notasParaProcessar);
            Task.WaitAll(processamentoDeNotasFiscaisServices.ProcessarNotas(notasParaProcessar));

            // Inutilizar notas
            InutilizarNotas(situacaoDaNotaRerpository, notasParaProcessar);
            Task.WaitAll(processamentoDeNotasFiscaisServices.ProcessarNotas(notasParaProcessar));

            Console.ReadKey();
        }

        private static void CancelarNotas(ISituacaoDaNotaRepository situacaoDaNotaRerpository, ICollection<NotaFiscal> notasFiscais)
        {
            var pendenteDeCancelamento = situacaoDaNotaRerpository.GetByType<PendenteDeCancelamento>();
            foreach (var nf in notasFiscais)
                nf.SetSituacao(pendenteDeCancelamento);
        }

        private static ICollection<NotaFiscal> GetNotas(ISituacaoDaNotaRepository situacaoDaNotaRerpository)
        {
            var notaFiscal1 = new NotaFiscalBuilder()
                .WithCnpjDaLoja("12605982000124")
                .WithModelo(55)
                .WithNumero(10)
                .WithSerie(1)
                .WithSituacao(situacaoDaNotaRerpository.GetByType<NaoAutorizada>())
                .WithValorTotal(100.00m)
                .Build();

            var notaFiscal2 = new NotaFiscalBuilder()
                .WithCnpjDaLoja("12605982000124")
                .WithModelo(65)
                .WithNumero(900)
                .WithSerie(3)
                .WithSituacao(situacaoDaNotaRerpository.GetByType<NaoAutorizada>())
                .WithValorTotal(150.00m)
                .Build();

            var notaFiscal3 = new NotaFiscalBuilder()
                .WithCnpjDaLoja("12605982000124")
                .WithModelo(55)
                .WithNumero(11)
                .WithSerie(1)
                .WithSituacao(situacaoDaNotaRerpository.GetByType<NaoAutorizada>())
                .WithValorTotal(10.00m)
                .Build();

            return new List<NotaFiscal> { notaFiscal1, notaFiscal2, notaFiscal3 };
        }

        private static void InutilizarNotas(ISituacaoDaNotaRepository situacaoDaNotaRerpository, ICollection<NotaFiscal> notasFiscais)
        {
            var pendenteDeInutilizacao = situacaoDaNotaRerpository.GetByType<PendenteDeInutilizacao>();
            foreach (var nf in notasFiscais)
                nf.SetSituacao(pendenteDeInutilizacao);
        }
    }
}