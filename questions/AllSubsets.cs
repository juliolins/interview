using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class AllSubsets
    {

        public static void Test()
        {
            List<char> set = new List<char>();
            set.Add('a'); set.Add('b'); set.Add('c');

            List<List<char>> subsets = new List<List<char>>();
            subsets.Add(new List<char>()); //empty

            //CreateSubsets(subsets, set);


            List<List<char>> result = CreateSubsets(set);

            Print(result);
        }


        public static void Print(List<List<char>> subsets)
        {
            foreach (List<char> set in subsets)
            {
                Console.Write("{");
                foreach (char ch in set)
                {
                    Console.Write(ch + ", ");
                }
                Console.WriteLine("}");
            }
        }

        public static void CreateSubsets(List<List<char>> subsets, List<char> set)
        {
            //base case: empty set
            if (set.Count == 0) 
            {
                //result is an empty set
                subsets.Add(new List<char>());
            }
            //P(1) case: add element to all sets
            else if (set.Count == 1)
            {
                List<List<char>> tempSet = new List<List<char>>();

                foreach (List<char> aSet in subsets)
                {
                    //clone the subset
                    List<char> newSet = new List<char>(aSet);

                    //add new element
                    newSet.Add(set.ElementAt(0));

                    //add the temp set
                    tempSet.Add(newSet);
                }

                //add the new sets
                subsets.AddRange(tempSet);
            }
            else
            {
                foreach (char element in set)
                {
                    //create a set with one element
                    List<char> newSet = new List<char>();

                    //add element
                    newSet.Add(element);

                    //recursivelly each element
                    CreateSubsets(subsets, newSet);
                }
            }
        }


        public static List<List<char>> CreateSubsets(List<char> set)
        {
            List<List<char>> result = new List<List<char>>();

            //generate all numbers as a code 000100
            int codesSize = 1 << set.Count; //2^n

            for (int i = 0; i < codesSize; i++)
            {
                List<char> subset = CreateOneSubset(i, set);
                result.Add(subset);
            }

            return result;
        }

        public static List<char> CreateOneSubset(int code, List<char> set)
        {
            List<char> subset = new List<char>();

            for (int i = 0; i < set.Count; i++)
            {
                if (((code >> i) & 1) == 1)
                {
                    subset.Add(set.ElementAt(i));
                }
            }

            return subset;
        }

    }
}
