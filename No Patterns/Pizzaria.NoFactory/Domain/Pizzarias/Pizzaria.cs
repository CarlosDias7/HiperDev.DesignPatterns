using MakePizzas.NoFactory.Domain.Pizzarias.Dtos;
using MakePizzas.NoFactory.Domain.Pizzas;
using MakePizzas.NoFactory.Domain.Pizzas.Tipos;

namespace MakePizzas.NoFactory.Domain.Pizzarias
{
    public class Pizzaria
    {
        public void Escolher(MakePizzaDto dto)
        {
            IPizza pizza = null;

            if (dto.IsQuatroQueijos)
            {
                pizza = new PizzaDeQuatroQueijos();
            }

            if (dto.IsLomboComRequeijao)
            {
                pizza = new PizzaDeLomboComRequeijao();
            }

            if (dto.IsVegetariana)
            {
                pizza = new PizzaVegetariana();
            }

            if (dto.IsAModaMineira)
            {
                pizza = new PizzaAModaMineira();
            }

            if (pizza == null) return;

            pizza.Preparar();
            pizza.Assar();
        }
    }
}