using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services
{
    public static class Factory
    {
        static Factory() 
        {
            Instance = new ObjectRecipesServices();
        }

        public static AbstractRecipesServices Instance { get; private set; }
    }
}
