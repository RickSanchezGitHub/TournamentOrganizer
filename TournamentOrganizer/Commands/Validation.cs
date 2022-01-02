using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.UI.Commands
{
   public static class Validation
    {
        public static string invalidSymbols = "1234567890!@#$%^&*()_+=";
        public static bool TextBoxValidation(string text)
        {
            bool isValid = true;
            string textTrim = text.Trim();
            foreach (var item in invalidSymbols)
            {
                if (textTrim.Contains(item))
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}

