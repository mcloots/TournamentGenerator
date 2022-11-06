using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace TournamentGenerator.Helper
{
    public static class ColumnMap
    {
        public static Dictionary<int, string> Columns
        {
            get
            {
                var dictionary = new Dictionary<int, string>();
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    int key = c - 'A' + 1;
                    dictionary.Add(key, c.ToString());
                }

                return dictionary;
            }
        }
    }
}
