using GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais;
using GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Builders;
using GeradorDeNotasFiscais.WithBuilder.Domain.NotasFiscais.Situacoes.Tipos;
using System;

namespace GeradorDeNotasFiscais.WithBuilder
{
    internal class Program
    {
        private static NotaFiscal GetNotaAutorizada()
        {
            return new NotaFiscal("12605982000124", 55, 1, 1, new Autorizada(), 10.00m);
        }

        private static NotaFiscal GetNotaCancelada()
        {
            return new NotaFiscal("12605982000124", 55, 1, 1, new Cancelada(), 10.00m);
        }

        private static NotaFiscal GetNotaNaoAutorizada()
        {
            return new NotaFiscal("12605982000124", 55, 1, 1, new NaoAutorizada(), 10.00m);
        }

        private static void Main(string[] args)
        {
            var nfNaoAutorizada = GetNotaAutorizada();
            var nfAutorizada = GetNotaAutorizada();
            var nfCancelada = GetNotaCancelada();
        }

        private NotaFiscal GetNotaAutorizadaBulder()
                    => new NotaFiscalBuilder()
                .WithCnpjDaLoja("12605982000124")
                .WithModelo(55)
                .WithNumero(1)
                .WithSerie(1)
                .WithSituacao(new Autorizada())
                .WithValorTotal(10.00m)
                .Build();

        private NotaFiscal GetNotaCanceladaBulder()
                    => new NotaFiscalBuilder()
                .WithCnpjDaLoja("12605982000124")
                .WithModelo(55)
                .WithNumero(1)
                .WithSerie(1)
                .WithSituacao(new Cancelada())
                .WithValorTotal(10.00m)
                .Build();

        private NotaFiscal GetNotaNaoAutorizadaBulder()
                                    => new NotaFiscalBuilder()
                .WithCnpjDaLoja("12605982000124")
                .WithModelo(55)
                .WithNumero(1)
                .WithSerie(1)
                .WithSituacao(new NaoAutorizada())
                .WithValorTotal(10.00m)
                .Build();
    }
}