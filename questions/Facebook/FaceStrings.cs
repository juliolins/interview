using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Facebook
{
    public static class FaceStrings
    {
        public static void Test()
        {
            Console.WriteLine(AnagramOccurs("abc", "decbafg"));
            Console.WriteLine(AnagramOccurs("abc", "deacbafg"));
            Console.WriteLine(AnagramOccurs("casa", "aaasacafg"));

        }

        //Given a string A and B return true if A occurs as an anagram in B  
        public static bool AnagramOccurs(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return false;
            }

            //use a hashmap and a and a match count to check if all chars were found in a
            //window inside b
            var charCount = new Dictionary<char, int>();
            for (int i = 0; i < a.Length; i++)
            {
                charCount.AddOneOrIncrement(a[i]);
            }

            //iterate through b keep tracking of how many matches are found
            //define the window
            int left = 0;
            for (int right = 0; right < b.Length; right++)
            {
                char ch = b[right];

                //ch is in a
                if (charCount.ContainsKey(ch))
                {
                    //if there's count left consume
                    if (charCount[ch] > 0)
                    {
                        charCount[ch]--;
                    }
                    else
                    {
                        //need to move left until we have a spot
                        while (charCount[ch] == 0)
                        {
                            charCount.SafeIncrement(b[left++]);
                        }

                        //then add again
                        charCount[ch]--;
                    }
                }
                else //ch is not in a
                {
                    while (left < right)
                    {
                        charCount.SafeIncrement(b[left++]);
                    }
                }

                //if we ever get the distance, there's a substring
                if (right - left == a.Length - 1)
                {
                    return true;
                }
                
            }

            return false;
        }

        public static void AddOneOrIncrement(this Dictionary<char, int> dic, char key)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = dic[key] + 1;
            }
            else
            {
                dic.Add(key, 1);
            }
        }

        public static bool SafeIncrement(this Dictionary<char, int> dic, char key)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = dic[key] + 1;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /*

    1 -> A
    2 -> B
    3 -> C
    ...
    10 -> J
    11 -> K
    ...
    26 -> Z


    111
    AAA
    AK
    KA
    => 3

    11|1
    count: 3

    int Count(string numbers, char[] map)
    {
        return Count(numbers, new int[numbers.Length], 0);   
    }

    int Count(string numbers, int[] cache, int startIndex)
    {
        if (cache[startIndex] > 0)
        {
            return cache[startIndex];
        }

        //base case, leaf node in the path tree
        if (startIndex == numbers.Length)
        {
            return 1;
        }

        int count = 0;
    
        for (int i = startIndex; i < numbers.Length; i++)
        {
            //check single digit
            int single = numbers[i].AsInt();
            if (single >= 1 && single <= 9)
            {
                count += Count(numbers, map, i + 1);
            }
            else 
            {
                //not a valid path
                return 0;
            }
        
            if (i < numbers.Length - 1)
            {
                int number = GetInt(numbers, i, i + 1);
            
                //if the double digit number is valid, count it
                if (number >= 1 && number <= 26)
                {
                    count += Count(numbers, map, i + 2);
                }
            }
        }
    
        cache[startIndex] = count;
        return count;
    }

    int GetInt(string numbers, int start, int end)
    {
    }  
 
    */
}
