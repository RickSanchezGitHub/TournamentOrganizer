using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.UI.Validation
{
    public static class Validation
    {
        private static string _invalidSymbols = "1234567890-=!@#$%^&*()_+ ";

        public static bool TextBoxValidation(string text)
        {
            bool isValid = true;
            string textTrim = text.Trim();
            foreach (var item in _invalidSymbols)
            {
                if(textTrim.Contains(item) || textTrim.Length>25)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        public static bool TextBoxValidationIsEmptyOrWriteSpace(string text)
        {
            bool isValid = true;
            if(string.IsNullOrWhiteSpace(text))
            {
                isValid = false;
            }
            return isValid;
        }

    }
}
