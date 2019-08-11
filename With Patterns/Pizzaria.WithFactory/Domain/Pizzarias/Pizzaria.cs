using MakePizzas.WithFactory.Domain.Pizzarias.Dtos;
using MakePizzas.WithFactory.Domain.Pizzas.Factory;

namespace MakePizzas.WithFactory.Domain.Pizzarias
{
    public class Pizzaria
    {
        private readonly IPizzaFactory _pizzaFactory;

        public Pizzaria(IPizzaFactory pizzaFactory)
        {
            _pizzaFactory = pizzaFactory;
        }

        public void Preparar(MakePizzaDto dto)
        {
            var pizza = _pizzaFactory.Fabricar(dto);
            if (pizza == null) return;

            pizza.Preparar();
            pizza.Assar();
        }
    }
}