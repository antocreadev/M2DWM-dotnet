using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace M2Corte2025.FormationFred.Services
{
    public class Xml1RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var xdoc = new XmlDocument();

            xdoc.Load("recipes.xml");

            var nodes = xdoc.SelectNodes("/recipes/recipe");

            var recipes = new List<Recipe>();

            foreach (XmlNode node in nodes)
            {
                Guid? id = Guid.Parse(node?.Attributes["id"].Value);
                String title = node?.Attributes["title"].Value;

                recipes.Add(
                    new Recipe() { Id = id.Value, Title=title }
                    );
            }

            return recipes;

        }

        public override List<Recipe> GetByTitle(string title)
        {
            return GetAll().Where(@recipe => @recipe.Title.Contains(title)).ToList();
        }
    }
}
