using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace M2Corte2025.FormationFred.Services
{
    public class Xml2RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            XDocument xdoc = XDocument.Load("recipes.xml");

            return xdoc.Descendants("recipe").Select(@recipe => new Recipe() { Id = Guid.Parse(@recipe.Attribute("id").Value), Title = recipe.Attribute("title").Value }).ToList();
        }
    }
}
