using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.CrackingTough
{
    public class SortByType_Jorge_Test
    {
        public static void Test()
        {
            MyType[] array = new MyType[] { MyType.A, MyType.B, MyType.C, MyType.A, MyType.B, MyType.C, MyType.A, MyType.B, MyType.C };

            array.PrintToConsole();
            SortByType_Jorge.Sort(array, new MyType[] { MyType.A, MyType.B, MyType.C });
            array.PrintToConsole();
        }
    }

    public enum MyType { A, B, C }

    public class SortByType_Jorge
    {
        public static void Sort(MyType[] array, MyType[] typeArray)
        {
            int placeLeft = 0;
            int placeRight = array.Length - 1;

            int typeLeft = 0;
            int typeRight = typeArray.Length - 1;

            while (placeLeft < placeRight && typeLeft < typeRight)
            {
                var result = Sort(array, typeArray[typeLeft], typeArray[typeRight], placeLeft, placeRight);
                typeLeft++;
                typeRight--;
                placeLeft = result.LeftPlace;
                placeRight = result.RightPlace;
            }
        }

        static PlacementResult Sort(MyType[] array, MyType typeA, MyType typeB, int left, int right)
        {
            int placeLeft = left;
            int placeRight = right;

            while (array[placeLeft] == typeA)
            {
                placeLeft++;
            }

            while (array[placeRight] == typeB)
            {
                placeRight--;
            }

            for (int i = placeLeft; i <= placeRight;)
            {
                if (array[i] == typeA)
                {
                    array.Swap(i, placeLeft++);
                }
                else if (array[i] == typeB)
                {
                    array.Swap(i, placeRight--);
                }
                else
                {
                    i++;
                }
            }

            return new PlacementResult() { LeftPlace = placeLeft, RightPlace = placeRight };
        }

        class PlacementResult
        {
            public int LeftPlace { get; set; }
            public int RightPlace { get; set; }
        }
    }
}
