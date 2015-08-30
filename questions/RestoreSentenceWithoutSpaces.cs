using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{

    //"thereisacat" 
    //"homelandsecurityisnecessary"

    /// <summary>
    /// Recover a sentence re-adding spaces assuming there's a dictionary available
    /// bool IsWord(string);
    /// </summary>
    public class RestoreSentenceWithoutSpaces
    {
        public static void Test()
        {
            var restorer = new RestoreSentenceWithoutSpaces();

            Console.WriteLine("[" + restorer.Restore("thereisacat") + "]");
        }



        private List<string> dictionary = new List<string>() { "the", "there", "is", "a", "cat" };

        public string Restore(string sentence)
        {
            return DoRestore(sentence, 0);
        }

        private string DoRestore(string sentence, int start)
        {
            for (int i = start; i <= sentence.Length; i++)
            {
                string temp = sentence.Substring(start, i - start);

                if (IsWord(temp))
                {
                    //make sure the next is also a word if not at the end
                    if (i == sentence.Length)
                    {
                        return temp;
                    }
                    else
                    {
                        string nextWords = DoRestore(sentence, i);
                        if (nextWords != null)
                        {
                            return temp + " " + nextWords;
                        }
                    }
                }
            }

            return null;
        }


        private bool IsWord(string word) 
        {
            return dictionary.Contains(word);
        }

    }
}
