using System;
using HiperDev.Extensions.NativeTypesExtensions;
using MakePizzas.NoFactory.Domain.Pizzarias;
using MakePizzas.NoFactory.Domain.Pizzarias.Dtos;

namespace MakePizzas.NoFactory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("*** Bem vindo ao MakePizzas.NoFactory! ***");

            do
            {
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("1 - Quatro Queijos");
                Console.WriteLine("2 - Lombo com Requeijão");
                Console.WriteLine("3 - Vegetariana");
                Console.WriteLine("4 - A moda mineira");

                Console.WriteLine("Escolha um sabor:");
                var result = Console.ReadLine().Trim();

                if (!ValidarEscolhaDaPizza(result))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                var pizzaria = new Pizzaria();
                pizzaria.Escolher(MontarDto(result.ToInt()));

                var continuarLoop = false;
                do
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("Deseja pedir outra pizza? (S/N)");
                    result = Console.ReadLine().Trim();

                    if (!ValidarSeDesejaOutraPizza(result, out continuarLoop))
                    {
                        Console.WriteLine("Opção inválida!");
                        continue;
                    }

                    break;
                } while (true);

                if (!continuarLoop) break;
            } while (true);
        }

        private static MakePizzaDto MontarDto(int sabor)
        {
            switch (sabor)
            {
                case 1:
                    return new MakePizzaDto { IsQuatroQueijos = true };

                case 2:
                    return new MakePizzaDto { IsLomboComRequeijao = true };

                case 3:
                    return new MakePizzaDto { IsVegetariana = true };

                case 4:
                    return new MakePizzaDto { IsAModaMineira = true };

                default:
                    throw new InvalidOperationException();
            }
        }

        private static bool ValidarEscolhaDaPizza(string valor) => int.TryParse(valor, out var numInt) && numInt.Between(1, 4);

        private static bool ValidarSeDesejaOutraPizza(string valor, out bool continuarLoop)
        {
            continuarLoop = false;
            valor = valor.ToUpper();

            if (!valor.In("S", "N")) return false;
            if (valor.Equals("S")) continuarLoop = true;

            return true;
        }
    }
}