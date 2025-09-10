using System.Collections.Generic;

namespace DataContracts
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public string Instructions { get; set; }
        public int PrepTime { get; set; } // in minutes
        public int CookTime { get; set; } // in minutes

        public Recipe() { }

        public Recipe(string name, List<string> ingredients, string instructions, int prepTime, int cookTime)
        {
            Name = name;
            Ingredients = ingredients;
            Instructions = instructions;
            PrepTime = prepTime;
            CookTime = cookTime;
        }
    }
}
