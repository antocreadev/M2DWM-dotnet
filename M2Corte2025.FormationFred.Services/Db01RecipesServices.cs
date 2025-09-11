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
            var recipes = new List<Recipe>();

            using (var cn = new SqlConnection(cs))
            {
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = "SELECT * FROM tRecipes";
                cmd.CommandType = System.Data.CommandType.Text;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = Guid.Parse(reader["Id"].ToString());
                    var title = reader["Title"].ToString();

                    recipes.Add(
                        new Recipe() { Id = id, Title=title}
                        );
                }

                return recipes;
            }
        }

        public override List<Recipe> GetByTitle(string ptitle)
        {
            var cs = "RecipesConnectionString".GetConfigValueFor("ConnectionStrings");
            var recipes = new List<Recipe>();

            using (var cn = new SqlConnection(cs))
            {
                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = $"SELECT * FROM tRecipes WHERE Title LIKE '%' + '{ptitle}' + '%'";
                cmd.CommandType = System.Data.CommandType.Text;

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
