using GeradorDeNotasFiscais.NoPattern.Domain.NotasFiscais;
using GeradorDeNotasFiscais.NoPattern.Domain.NotasFiscais.Situacoes.Tipos;
using System;

namespace GeradorDeNotasFiscais.NoPattern
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
    }
}