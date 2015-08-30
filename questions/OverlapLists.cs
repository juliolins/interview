using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class OverlapLists
    {

        public static void TestProcess()
        {
            IList<Interval> list = new List<Interval>();
            list.Add(new Interval(1, 5));
            list.Add(new Interval(3, 10));

            IList<Interval> result = ProcessList_2(list);

            foreach (Interval item in result)
            {
                Console.Write(string.Format("({0},{1}) ", item.start, item.end));
            }
        }

        public static IList<Interval> ProcessList_2(IList<Interval> list)
        {
            IList<Interval> result = new List<Interval>();
            IList<Interval> toBeRemoved = new List<Interval>();

            bool keep = true;
            foreach (Interval interval in list)
            {
                Interval newInterval = new Interval(interval.start, interval.end);
                keep = true;

                foreach (Interval fixInterval in list)
                {
                    if (interval.Equals(fixInterval)) continue;

                    //if the interval is contained, it can be simply removed
                    if (newInterval.start >= fixInterval.start && newInterval.end <= fixInterval.end)
                    {
                        keep = false;
                        break;
                    }

                    //fix the start so it stays out of other intervals
                    if (newInterval.start >= fixInterval.start && newInterval.start <= fixInterval.end)
                    {
                        newInterval.start = fixInterval.end;
                    }

                    //fix the end so it stays out of other intervals
                    if (newInterval.end >= fixInterval.start && newInterval.end <= fixInterval.end)
                    {
                        newInterval.end = fixInterval.start;
                    }
                }

                if (keep)
                {
                    result.Add(newInterval);
                }
            }

            return result;
        }

        public static IList<Interval> ProcessList(IList<Interval> list)
        {
            IList<Interval> result = new List<Interval>();

            bool keep = true;
            foreach (Interval interval in list)
            {

                //keep editing the interval so it doesn't conflict with existing ranges
                foreach (Interval doneInterval in result)
                {
                    //if the interval is contained, it can be simply removed
                    if (interval.start >= doneInterval.start && interval.end <= doneInterval.end)
                    {
                        keep = false;
                        break;
                    }

                    //fix the start so it stays out of other intervals
                    if (interval.start >= doneInterval.start && interval.start <= doneInterval.end)
                    {
                        interval.start = doneInterval.end;
                    }

                    //fix the end so it stays out of other intervals
                    if (interval.end >= doneInterval.start && interval.end <= doneInterval.end)
                    {
                        interval.end = doneInterval.start;
                    }
                }

                if (keep)
                {
                    result.Add(interval);
                }
                else
                {
                    keep = true;
                    continue;
                }
            }

            return result;
        }

        public static void RemoveOverlap(Interval doneInterval, Interval interval)
        {
            //if (interval.start >=  <= doneInterval.start

        }
    }

    public class Interval
    {
        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public int start;
        public int end;

        public override bool Equals(object obj)
        {
            Interval other = obj as Interval;

            return other.start == this.start && other.end == this.end;
        }
    }
}
