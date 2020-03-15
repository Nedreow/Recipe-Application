using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_Application
{
    class Recipe
    {
        public string Name { get; }

        public Dictionary<Ingredient, int> Ingredients { get; }

        public AllergyWarnings AllergyWarnings { get; }

        public NutritionTable NutritionTable { get; }

        public List<string> CookingSteps { get; set; }

        public string Description { get; }

        public int Time { get; }

        public int Portions { get; set; }

        public List<string> Commentary { get; set; }

        public Recipe(string name, string description, int time, int portions, List<string> cookingSteps, Dictionary<Ingredient, int> ingredients, List<string> commentary = null)
        {
            Name = name;
            Description = description;
            Time = time;
            Portions = portions;
            CookingSteps = cookingSteps;
            Ingredients = ingredients;
            Commentary = commentary;

            var allergyLists = new List<AllergyWarnings>();
            foreach (var ingredient in Ingredients)
            {
                allergyLists.Add(ingredient.Key.AllergyList);
            }
            AllergyWarnings = new AllergyWarnings(allergyLists);

            NutritionTable = CreateNutritionTable();
        }

        public NutritionTable CreateNutritionTable()
        {
            var nutritionDict = new Dictionary<string, int>();

            foreach (var ingredient in Ingredients)
            {
                foreach (var nutrient in ingredient.Key.NutritionalValues)
                {
                    int nutrients = ingredient.Value * nutrient.Value;

                    if (nutritionDict.ContainsKey(nutrient.Key))
                    {
                        nutritionDict[nutrient.Key] = nutritionDict[nutrient.Key] + nutrients;
                    }
                    else
                    {
                        nutritionDict.Add(nutrient.Key, nutrients);
                    }
                }
            }

            return new NutritionTable(nutritionDict);
        }

        public void AddIngredient(Ingredient ingredient, int amount = 1)
        {
            Ingredients.Add(ingredient, amount);
        }

        public void AddCookingStep(string step, int index = -1)
        {
            if (index == -1)
            {
                CookingSteps.Add(step);
                return;
            }

            CookingSteps.Insert(index, step);
        }
    }
}
