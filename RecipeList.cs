using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_Application
{
    public class RecipeList
    {
        public string Name { get; }

        public User User { get; }

        public List<Recipe> Recipes { get; }

        public RecipeList(string name, User user = null)
        {
            Name = name;
            User = user ?? User.GetDefaultUser();
        }

        public RecipeList(string name, List<Recipe> recipes, User user = null) : this(name, user)
        {
            Recipes = recipes;
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }
    }
}
