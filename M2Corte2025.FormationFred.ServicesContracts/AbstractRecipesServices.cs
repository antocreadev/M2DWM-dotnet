using M2Corte2025.FormationFred.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.ServicesContracts
{
    public abstract class AbstractRecipesServices
    {
        public abstract List<Recipe> GetAll();

    }
}
