using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Electronics.Logic.FilteringChecks
{
    public static class VulgarTextCheck
    {

        public static bool CheckForWords(string input)
        {
            bool badWordPresent = false;

            List<string> words = ProfanityWords.VulgarWords;

            foreach (string word in words)
            {
                if (input.Contains(word.ToLower()))
                {
                    badWordPresent = true;
                }
            }

            return badWordPresent;
        }
    }
}
