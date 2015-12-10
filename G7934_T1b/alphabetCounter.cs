using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G7934_T1b
{
    class AlphabetCounter
    {
        int[] chars = new int[(int)char.MaxValue];

        public int[] countAlphabets(String s)
        {
            char[] letters = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                letters[i] = char.ToUpper(letters[i]);
            }
            s = new string(letters);
            foreach (char c in s)
            {
                chars[(int)c]++;
            }
            return chars;
        }

        public bool checkForContent(String s)
        {
            if (s.Length > 0)
            {
                foreach (char c in s)
                {
                    if (char.IsDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    } 
}
