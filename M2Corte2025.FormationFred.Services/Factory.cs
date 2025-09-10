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

            Instance = Activator.CreateInstance(assemblyFileName, className).Unwrap() as AbstractRecipesServices;

            // Guillaume Pley : legends platist
        }

        public static AbstractRecipesServices? Instance { get; private set; }
    }
}
