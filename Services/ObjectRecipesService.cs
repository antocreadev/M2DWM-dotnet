using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContracts;
using ServicesContracts;

namespace Services
{
    public class ObjectRecipesService : IAbstractRecipesService
    {
        private List<Recipe> _recipes = new List<Recipe>();

        public ObjectRecipesService()
        {
            // Initialize with some sample recipes
            _recipes.Add(new Recipe("Pasta Carbonara", new List<string> { "Pasta", "Eggs", "Bacon", "Cheese" }, "Cook pasta, mix with eggs and bacon.", 10, 15));
            _recipes.Add(new Recipe("Chicken Stir Fry", new List<string> { "Chicken", "Vegetables", "Soy Sauce" }, "Stir fry chicken and veggies.", 15, 10));
        }

        public Task<List<Recipe>> GetRecipesAsync()
        {
            return Task.FromResult(_recipes);
        }

        public Task<Recipe> GetRecipeByNameAsync(string name)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name == name);
            return Task.FromResult(recipe);
        }

        public Task AddRecipeAsync(Recipe recipe)
        {
            _recipes.Add(recipe);
            return Task.CompletedTask;
        }

        public Task UpdateRecipeAsync(Recipe recipe)
        {
            var existing = _recipes.FirstOrDefault(r => r.Name == recipe.Name);
            if (existing != null)
            {
                existing.Ingredients = recipe.Ingredients;
                existing.Instructions = recipe.Instructions;
                existing.PrepTime = recipe.PrepTime;
                existing.CookTime = recipe.CookTime;
            }
            return Task.CompletedTask;
        }

        public Task DeleteRecipeAsync(string name)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name == name);
            if (recipe != null)
            {
                _recipes.Remove(recipe);
            }
            return Task.CompletedTask;
        }
    }
}
