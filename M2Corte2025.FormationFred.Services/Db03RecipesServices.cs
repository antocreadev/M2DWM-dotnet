using M2Corte2025.FormationFred.DataContracts;
using M2Corte2025.FormationFred.Services.Core;
using M2Corte2025.FormationFred.ServicesContracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.Services
{
    public class Db03RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

            DbProviderFactory factory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");

            using (var cn = factory.CreateConnection())
            {
                cn.ConnectionString = "RecipesConnectionString".GetConfigValueFor("ConnectionStrings");

                cn.Open();

                var cmd = cn?.CreateCommand();

                cmd.CommandText = "sSelectRecipes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var recipes = new List<Recipe>();

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

        public override List<Recipe> GetByTitle(string pTitle)
        {
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

            DbProviderFactory factory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");

            using (var cn = factory.CreateConnection())
            {
                cn.ConnectionString = "RecipesConnectionString".GetConfigValueFor("ConnectionStrings");

                cn.Open();

                var cmd = cn?.CreateCommand();

                cmd.CommandText = "sSelectRecipes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var param = cmd.CreateParameter();
                param.ParameterName = "@title";
                param.Value = pTitle;
                cmd.Parameters.Add(param);

                var recipes = new List<Recipe>();

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
