using System.Collections.Generic;

namespace Recipe_Application
{
    class Program
    {
        
    }

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

    class Ingredient
    {
        public string Name { get; }

        public Dictionary<string, int> NutritionalValues { get; }

        public string QuantityUnit { get; }

        public AllergyWarnings AllergyList { get; }

        public Ingredient(string name, Dictionary<string, int> nutritionalValues, string quantityUnit = "grams", List<string> allergyList = null)
        {
            Name = name;
            NutritionalValues = nutritionalValues;
            QuantityUnit = quantityUnit;
            AllergyList = new AllergyWarnings(allergyList);
        }
    }

    class NutritionTable
    {
        public Dictionary<string, int> NutritionValues { get; }

        public NutritionTable()
        {
            NutritionValues = new Dictionary<string, int>();
        }

        public NutritionTable(Dictionary<string, int> values)
        {
            NutritionValues = values;
        }
    }

    class AllergyWarnings
    {
        public List<string> Warnings { get; }

        public AllergyWarnings()
        {
            Warnings = new List<string>();
        }

        public AllergyWarnings(List<string> warnings)
        {
            Warnings = warnings;
        }

        public AllergyWarnings(List<AllergyWarnings> warningLists)
        {
            var newList = new List<string>();

            foreach (var warningList in warningLists)
            {
                foreach (var warning in warningList.Warnings)
                {
                    if (!newList.Contains(warning))
                    {
                        newList.Add(warning);
                    }
                }
            }

            Warnings = newList;
        }
    }
}
