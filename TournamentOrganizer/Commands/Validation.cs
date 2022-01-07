using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.UI.Commands
{
    public static class Validation
    {
        public static string invalidSymbols = "1234567890!@#$%^&*()_+= ";
        public static bool TextBoxValidation(string text)
        {
            bool isValid = true;
            string textTrim = text.Trim();
            foreach (var item in invalidSymbols)
            {
                if (textTrim.Contains(item) || textTrim.Length>25)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        public static bool TextBoxValidationIsEmptyOrWhiteSpace(string text)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(text))
            {
                isValid = false;
            }
            return isValid;
        }

        public static bool BirthdayValidation(DateTime birdthday)
        {
            if (DateTime.Now.Year - birdthday.Year < 14)
            {
                return true;
            }

            return false;
        }


    }
}
