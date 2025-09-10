using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace M2Corte2025.FormationFred.Services
{
    public class ObjectRecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>()
            {
                new Recipe() { Id = Guid.NewGuid(), Title = "Object Recipe 01"},
                new Recipe() { Id = Guid.NewGuid(), Title = "Object Recipe 02"},
                new Recipe() { Id = Guid.NewGuid(), Title = "Object Recipe 02"},
                new Recipe() { Id = Guid.NewGuid(), Title = "Object Recipe 03"}
            };

            return recipes;
        }
    }
}
