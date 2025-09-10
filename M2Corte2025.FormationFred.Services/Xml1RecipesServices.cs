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

            return null;
        }
    }
}
