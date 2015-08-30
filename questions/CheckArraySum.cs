using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class CheckArraySum
    {

        /*
//returns true if there's a subset (of any size) of the array which sums to k
bool CheckSum(int[] nums, int k)

[1, 3, -5, 10]
k == 11, true
k == -2, true
k == 7, false
k== 14, true
k==3, true
         
         */

        public static void Test()
        {
            int[] nums = new int[] {1, 3, -5, 10};

            Console.WriteLine(CheckSum(nums, 11));
            Console.WriteLine(CheckSum(nums, -2));
            Console.WriteLine(CheckSum(nums, 7));
            Console.WriteLine(CheckSum(nums, 14));
            Console.WriteLine(CheckSum(nums, 3));
        }

        public static bool CheckSum(int[] nums, int k)
        {
            return DoCheckSum(nums, k, 0, 0);
        }

        public static bool DoCheckSum(int[] nums, int k, int sum, int start)
        {

            for (int i = start; i < nums.Length; i++)
            {
                int newSum = sum + nums[i];

                if (newSum == k)
                {
                    return true;
                } else {

                    //call next item and return true if found
                    if (DoCheckSum(nums, k, newSum, i + 1))
                    {
                        return true;
                    }

                }
            }

            return false;
        }

    }
}
