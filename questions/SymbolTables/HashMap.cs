using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.SymbolTables
{
    public class HashMap
    {

        public static int Hash(string str)
        {
            int hash = 17;
            for (int i = 0; i < str.Length; i++)
            {
                hash = str[i] + 31 * hash;
            }
            return hash;
        }
    }
}
