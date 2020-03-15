using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_Application
{
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
