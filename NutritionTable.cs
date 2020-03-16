using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_Application
{
    public class NutritionTable
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
}
