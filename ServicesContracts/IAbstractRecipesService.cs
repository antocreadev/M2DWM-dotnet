using System.Collections.Generic;
using System.Threading.Tasks;
using DataContracts;

namespace ServicesContracts
{
    public interface IAbstractRecipesService
    {
        Task<List<Recipe>> GetRecipesAsync();
        Task<Recipe> GetRecipeByNameAsync(string name);
        Task AddRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(string name);
    }
}
