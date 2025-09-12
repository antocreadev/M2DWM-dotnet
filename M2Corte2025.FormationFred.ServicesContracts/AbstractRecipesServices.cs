using M2Corte2025.FormationFred.DataContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.ServicesContracts
{
    public abstract class AbstractRecipesServices
    {
        public abstract List<Recipe> GetAll();

        public abstract List<Recipe> GetByTitle(String title);

        protected List<Recipe> getInternalRecipes(String recipesConnectionString, String commandText, CommandType commandType)
        {
            var recipes = new List<Recipe>();

            using (var cn = new SqlConnection(recipesConnectionString))
            {
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = commandText;
                cmd.CommandType = commandType;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var title = reader["Title"].ToString();

                    recipes.Add(
                        new Recipe() { Id = id, Title = title }
                        );
                }

                return recipes;
            }
        }
    }
}
