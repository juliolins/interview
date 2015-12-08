using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.CrackingTough
{
    public class Sequences
    {

        public static void Test()
        {
            //var source = new List<Interval>() { new Interval(1, 5), new Interval(3, 10) };
            //var source = new List<Interval>() { new Interval(1, 5), new Interval(2, 4), new Interval(3, 7) };
            var source = new List<Interval>() { new Interval(1, 4), new Interval(2, 6), new Interval(3, 7), new Interval(3, 9) };
            RemoveIntersections(source).PrintToConsole();
        }

        internal static IEnumerable<Interval> RemoveIntersections(IEnumerable<Interval> source)
        {
            var result = new List<Interval>();

            Interval last = null;
            foreach (var next in source)
            {
                if (last == null)
                {
                    last = next;
                }
                else if (last.IsContainedIn(next))
                {
                    last = new Interval(last.End, next.End);
                }
                else if (last.Intersect(next))
                {
                    var newInterval = new Interval() { Start = last.Start, End = next.Start };
                    result.Add(newInterval);
                    last = new Interval() { Start = Math.Min(last.End, next.End), End = Math.Max(last.End, next.End)};
                }
                else 
                {
                    result.Add(next);
                    last = next;
                }
            }

            result.Add(last);

            return result;
        }

        
        internal class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }

            public Interval()
            {

            }

            public Interval(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }

            public bool IsContainedIn(Interval other)
            {
                return this.Start >= other.Start && this.End <= other.End;
            }

            public bool Intersect(Interval other)
            {
                return this.End > other.Start;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1})", Start, End);
            }
        }
    }
}
