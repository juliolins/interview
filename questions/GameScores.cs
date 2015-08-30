using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{

    public class GameScoreNode : IComparable
    {
        public int ValueSubtracted {get; set;}
        public SortedSet<GameScoreNode> Children {get; set;}

        public GameScoreNode(int valueSubtracted)
        {
            this.ValueSubtracted = valueSubtracted;
            this.Children = new SortedSet<GameScoreNode>();
        }

        public int CompareTo(object obj)
        {
            return ValueSubtracted.CompareTo(((GameScoreNode)obj).ValueSubtracted);
        }
    }

    public class GameScores2
    {

        public static void Test()
        {
            GameScoreNode root = BuildScoreTree(10, new int[] { 1, 2, 3 });
            PrintScoreTree(10, root);
        }

        /// <summary>
        /// Builds a n-ary tree with game score possibilities.
        /// </summary>
        /// <param name="totalScore">Total game points.</param>
        /// <param name="scores">List of possible scores</param>
        public static GameScoreNode BuildScoreTree(int totalScore, int[] scores)
        {
            //root has a zero as the subtracted node
            GameScoreNode root = new GameScoreNode(0);

            //starts recursion
            Score(totalScore, root, scores);

            return root;
        }

        /// <summary>
        /// Recursivelly adds scores changes to a root node.
        /// Assumes root is non-null.
        /// </summary>
        private static void Score(int scoreLeft, GameScoreNode root, int[] scores)
        {
            //for each score 1, 2, 3, subtract it from current game score by adding a new node
            for (int i = 0; i < scores.Length; i++)
            {
                int nextScore = scoreLeft - scores[i];

                //if there's score to be consumed, add a new node and recurse
                if (nextScore >= 0)
                {
                    GameScoreNode newPointNode = new GameScoreNode(scores[i]);
                    Score(nextScore, newPointNode, scores);
                    root.Children.Add(newPointNode);
                }
            }
        }

        /// <summary>
        /// Prints the tree by using a stack and keeping track of the score left
        /// </summary>
        public static void PrintScoreTree(int totalScore, GameScoreNode root)
        {
            Stack<int> scoreStack = new Stack<int>();

            //skips the root (zero) and recurse on each children
            foreach (GameScoreNode node in root.Children)
            {
                FindLeafAndPrint(totalScore, node, scoreStack);
            }               
        }

        /// <summary>
        /// Find the leaves of a the tree and prints the path.
        /// </summary>
        private static void FindLeafAndPrint(int scoreLeft, GameScoreNode root, Stack<int> scoreStack)
        {
            //pushes the node value to the stack
            scoreStack.Push(root.ValueSubtracted);

            int newScore = scoreLeft - root.ValueSubtracted;

            //found a leaf? (root.Children is empty)
            if (newScore == 0)
            {
                PrintStack(scoreStack);
            }
            else
            {
                //not a leaf yet, so keep recursing
                foreach (GameScoreNode node in root.Children)
                {
                    FindLeafAndPrint(newScore, node, scoreStack);
                }
            }

            //remove current score from the stack when returning
            scoreStack.Pop();
        }

        private static void PrintStack(Stack<int> scoreStack)
        {
            foreach (int score in scoreStack)
            {
                Console.Write(score + " ");
            }

            Console.WriteLine();
        }
    }


    public class GameScores
    {

        public static void Test()
        {
            PrintPossibilities(20);
        }

        public static void PrintPossibilities(int totalScore)
        {
            //array size is [totalScore/minimumScoreStep]
            int[] points = new int[totalScore];
            Score(totalScore, points, 0);
        }

        /**
         * F(X) {
         *       if (X == 0) print();
         *       else { 
         *          F(X - 1);
         *          F(X - 2); 
         *          F(X - 4); 
         *          F(X - 5);
         *          }
         *      }
         */ 
        private static void Score(int scoreLeft, int[] pointHistory, int pointIndex)
        {
            //no more points to score
            if (scoreLeft == 0)
            {
                PrintPoints(pointHistory, pointIndex);
                return;
            }

            int newScore = scoreLeft - 1;

            if (newScore >= 0)
            {
                pointHistory[pointIndex] = 1;
                Score(newScore, pointHistory, pointIndex + 1);
            }

            newScore = scoreLeft - 2;
            if (newScore >= 0)
            {
                pointHistory[pointIndex] = 2;
                Score(newScore, pointHistory, pointIndex + 1);
            }

            newScore = scoreLeft - 4;
            if (newScore >= 0)
            {
                pointHistory[pointIndex] = 4;
                Score(newScore, pointHistory, pointIndex + 1);
            }

            newScore = scoreLeft - 5;
            if (newScore >= 0)
            {
                pointHistory[pointIndex] = 5;
                Score(newScore, pointHistory, pointIndex + 1);
            }
        }

        private static void PrintPoints(int[] pointHistory, int pointIndex)
        {
            for (int i = 0; i < pointIndex; i++)
            {
                Console.Write(pointHistory[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
