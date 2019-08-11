using System;
using System.Collections.Generic;
using System.Text;

namespace MakePizzas.NoFactory.Domain.Pizzarias.Dtos
{
    public class MakePizzaDto
    {
        public bool IsAModaMineira { get; set; }
        public bool IsLomboComRequeijao { get; set; }
        public bool IsQuatroQueijos { get; set; }
        public bool IsVegetariana { get; set; }
    }
}