using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Recipe_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Recipe
    {
        public string Name { get; }

        public Dictionary<Ingredient, int> Ingredients { get; }

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
        }

        public Dictionary<string, int> getNutritionalValues()
        {
            var nutritionDict = new Dictionary<string, int> { };

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

            return nutritionDict;
        }

        public List<string> getAllergyWarnings()
        {
            var allergyList = new List<string>{};

            foreach (var ingredient in Ingredients)
            {
                foreach (var warning in ingredient.Key.AllergyList)
                {
                    if (!allergyList.Contains(warning))
                    {
                        allergyList.Add(warning);
                    }
                }
            }

            return allergyList;
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

        public List<string> AllergyList { get; }

        public Ingredient(string name, Dictionary<string, int> nutritionalValues, string quantityUnit = "grams", List<string> allergyList = null)
        {
            Name = name;
            NutritionalValues = nutritionalValues;
            QuantityUnit = quantityUnit;
            AllergyList = allergyList;
        }
    }
}
