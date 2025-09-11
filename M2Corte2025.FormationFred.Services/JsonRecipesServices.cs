using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.ServicesContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services
{
    public class JsonRecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var json = File.ReadAllText("recipes.json");

            return JsonConvert.DeserializeObject<List<Recipe>>(json);
        }
    }
}
