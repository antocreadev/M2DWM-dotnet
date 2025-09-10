using M2Corte2025.FormationFred.Services.Core;
using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services
{
    public static class Factory
    {
        static Factory() 
        {
            var className = "ClassName".GetConfigValueFor();
            var assemblyFileName = "AssemblyFileName".GetConfigValueFor();

            Debug.WriteLine($"{assemblyFileName} {className}");

            Instance = new ObjectRecipesServices();
        }

        public static AbstractRecipesServices Instance { get; private set; }
    }
}
