using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.Services.Core;
using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services
{
    public class Db01RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var cs = "RecipesConnectionString".GetConfigValueFor("ConnectionStrings");

            return getInternalRecipes(cs, "SELECT * FROM tRecipes", System.Data.CommandType.Text);
        }

        public override List<Recipe> GetByTitle(string ptitle)
        {
            var cs = "RecipesConnectionString".GetConfigValueFor("ConnectionStrings");

            return getInternalRecipes(cs, $"SELECT * FROM tRecipes WHERE Title LIKE '%' + '{ptitle}' + '%'", System.Data.CommandType.Text);
        }
    }
}
