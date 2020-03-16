using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_Application
{
    public class Ingredient
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
}
