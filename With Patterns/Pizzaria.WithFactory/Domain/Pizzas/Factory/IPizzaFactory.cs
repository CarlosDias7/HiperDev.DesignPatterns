using MakePizzas.WithFactory.Domain.Pizzarias.Dtos;

namespace MakePizzas.WithFactory.Domain.Pizzas.Factory
{
    public interface IPizzaFactory
    {
        IPizza Fabricar(MakePizzaDto dto);
    }
}