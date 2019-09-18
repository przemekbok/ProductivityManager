using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BlokerStron.Validation
{
    public class BlackListInputValidation
    {
        public static bool CheckIfInputIsURL(string input)
        {
            //Regex regex = new Regex("^((https?|ftp|smtp):\\/\\/)?(www.)?[a-z0-9]+\\.[a-z]+(\\/[a-zA-Z0-9#]+\\/?)*$"); //<- Regex for url
            Regex regex = new Regex("^(www\\.)?[a-z0-9]+\\.[a-z]+(\\/[a-zA-Z0-9#]+\\/?)*$");
            return regex.IsMatch(input); 
        }

        public static bool ValidateAndAddAnInput(string input,StartWindow Parent)
        {
            if (CheckIfInputIsURL(input))
            {
                if (!input.Contains("www."))
                {
                    input = "www." + input;
                }

                if (!Parent.BlackList.Items.Contains(input))
                {
                    Parent.BlackList.Items.Add(input);
                    return true;
                }
                else
                {
                    MessageBox.Show("Taka strona już została podana!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Podana strona nie spełnia formatu! Poprawny format to {opcjonalnie www}.<adres>.<rozszerzenie>/{opcjonalna ścierzka}");
                return false;
            }
        }
    }
}
