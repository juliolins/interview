using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{


public class BinaryCode
{
    public bool IsSorted { get; set; }



    public string[] decode(string input)
    {
        char[] inputChar = input.ToCharArray();
        return new string[] { UnitDecode(inputChar, '0'), UnitDecode(inputChar, '1') };
    }

    private string UnitDecode(char[] input, char initial)
	{
		char[] decoded = new char[input.Length];
		decoded[0] = initial;
		int previous = 0;

        for (int i = 0; i < input.Length - 1; i++) 
		{
			int sumCorrent = input[i] - '0';
			int next = sumCorrent - previous - (decoded[i] - '0');
		
			if (next < 0 || next > 1) 
			{
				return "NONE";
			}

            previous = decoded[i] - '0';
			decoded[i + 1] = (char) (next + '0');
		}
		
		return new String(decoded);
	}

    public class LotteryComparer : System.Collections.Generic.IComparer<LotteryComparer>
    {
        public int Compare(LotteryComparer x, LotteryComparer y)
        {
            throw new NotImplementedException();
        }
    }

}




}
