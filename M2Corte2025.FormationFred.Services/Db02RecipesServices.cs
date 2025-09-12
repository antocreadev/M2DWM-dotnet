using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.Services.Core;
using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services
{
    public class Db02RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()

        {
            var cs = "RecipesConnectionString".GetConfigValueFor("ConnectionStrings");

            return getInternalRecipes(cs, "sSelectRecipes", System.Data.CommandType.StoredProcedure);
        }

        public override List<Recipe> GetByTitle(string title)
        {
            var cs = "RecipesConnectionString".GetConfigValueFor("ConnectionStrings");

            return getInternalRecipes(cs, "sSelectRecipes", System.Data.CommandType.StoredProcedure);
        }
    }
}
