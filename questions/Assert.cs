using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class Assert
    {
        public static void IsTrue(bool condition)
        {
            if (!condition) throw new Exception("Condition is false");
        }
    }
}
