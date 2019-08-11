using System;

namespace MakePizzas.WithFactory.Domain.Pizzas
{
    public abstract class Pizza : IPizza
    {
        public void Assar()
        {
            Console.WriteLine("Pizza assando..");
        }

        public void Preparar()
        {
            Console.WriteLine("Pizza em preparação..");
        }
    }
}