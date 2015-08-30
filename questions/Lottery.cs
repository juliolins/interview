
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
public class Lottery
{

    public static void Test()
    {
        string[] rules = {  "INDIGO: 93 8 T F", 
                            "ORANGE: 29 8 F T", 
                            "VIOLET: 76 6 F F",
                            "BLUE: 100 8 T T",
                            "RED: 99 8 T T",
                            "GREEN: 78 6 F T",
                            "YELLOW: 75 6 F F"};

        rules = new Lottery().sortByOdds(rules);


        Console.Write("{");
        for (int i = 0; i < rules.Length; i++)
        {
            Console.Write("\"" + rules[i] + "\"");
            if (i < rules.Length - 1) Console.Write(", ");
        }
        Console.Write("}");
        Console.WriteLine();

    }


    public bool IsSorted;
    public bool IsUnique;
    public string Name;
    public int Choices;
    public int Blanks;

    public double CalculateOdds()
    {
        double oddsInverse = 1;
        int step = 0;
        if (IsUnique) step = 1;
        int remainingChoices = Choices;
        for (int i = 0; i < Blanks; i++)
        {
            oddsInverse = oddsInverse * remainingChoices;
            remainingChoices = remainingChoices - step;
        }

        if (IsSorted)
        {
            oddsInverse = oddsInverse / Fat(Blanks);
        }

        return 1 / oddsInverse;
    }

    public static double Fat(double d)
    {
        if (d == 1) return 1;
        else return d * Fat(d - 1);
    }

    public static Lottery Parse(string rule)
    {
        Lottery lottery = new Lottery();
        int index = rule.LastIndexOf(":");

        lottery.Name = rule.Substring(0, index);
        string[] rest = rule.Substring(index + 1).Trim().Split(' ');

        lottery.Choices = int.Parse(rest[0]);
        lottery.Blanks = int.Parse(rest[1]);
        lottery.IsSorted = (rest[2] == "T") ? true : false;
        lottery.IsUnique = (rest[3] == "T") ? true : false;

        return lottery;
    }

    public string[] sortByOdds(string[] rules)
    {
        Lottery[] lotteries = new Lottery[rules.Length];
        for (int i = 0; i < rules.Length; i++)
        {
            lotteries[i] = Lottery.Parse(rules[i]);
        }

        Array.Sort<Lottery>(lotteries, new LotteryComparer());

        for (int i = 0; i < rules.Length; i++)
        {
            rules[i] = lotteries[i].Name;
        }

        return rules;
    }

    public class LotteryComparer : IComparer<Lottery>
    {
        public int Compare(Lottery x, Lottery y)
        {
            double d = x.CalculateOdds() - y.CalculateOdds();
            if (d < 0) return -1;
            else return 1;
        }
    }
}
}
