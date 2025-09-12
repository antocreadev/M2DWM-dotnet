using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.Services.DataAccessLayer;
using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services
{
    public class Db05RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            using (var context = new BRecipesContext())
            {
                return context.TRecipes.Select(@recipe => new Recipe() { Id = @recipe.Id, Title = @recipe.Title }).ToList();
            }
        }

        public override List<Recipe> GetByTitle(string title)
        {
            using (var context = new BRecipesContext())
            {
                return context.TRecipes.Where(@recipe => @recipe.Title.Contains(title)).Select(@recipe => new Recipe() { Id = @recipe.Id, Title = @recipe.Title }).ToList();
            }
        }
    }
}
