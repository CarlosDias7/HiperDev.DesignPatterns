using MakePizzas.WithFactory.Domain.Pizzarias.Dtos;
using MakePizzas.WithFactory.Domain.Pizzas.Tipos;

namespace MakePizzas.WithFactory.Domain.Pizzas.Factory
{
    public class PizzaFactory : IPizzaFactory
    {
        public IPizza Fabricar(MakePizzaDto dto)
        {
            if (dto.IsQuatroQueijos)
            {
                return new PizzaDeQuatroQueijos();
            }

            if (dto.IsLomboComRequeijao)
            {
                return new PizzaDeLomboComRequeijao();
            }

            if (dto.IsVegetariana)
            {
                return new PizzaVegetariana();
            }

            if (dto.IsAModaMineira)
            {
                return new PizzaAModaMineira();
            }

            return null;
        }
    }
}