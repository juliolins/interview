﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.SymbolTables
{
    public static class IntBSTTest
    {
        public static void Test()
        {
            //var bst = new IntBST(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9});

            //var bst = new IntBST();
            //var paths = bst.PathsWithSum(16);
            //foreach (var path in paths)
            //{
            //    path.PrintToConsole();
            //}

            //var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            //var bst = new IntBST();
            //bst.BuildFromArray(array);

            //Console.WriteLine(bst.MinHeight());

            Console.WriteLine(IntBST.IsPreOrder(new int[] { 40, 30, 35, 80, 100 }));
            Console.WriteLine(IntBST.IsPreOrder(new int[] { 40, 30, 35, 20, 80, 100 }));
        }
    }


    public class IntBST
    {
        private Node root;

        public IntBST()
        {
            //root = new Node() { Value = 5 };
            //root.Left = new Node() { Value = 8};
            //root.Left.Left = new Node() { Value = 3 };
            //root.Left.Left.Left = new Node() { Value = 2 };

            //root.Left.Right = new Node() { Value = 1 };
            //root.Left.Right.Left = new Node() { Value = 4 };
            //root.Left.Right.Right = new Node() { Value = 7 };
        }

        public IntBST(int[] array)
        {
            Insert(array, 0, array.Length - 1);    
        }

        private void Insert(int[] array, int start, int end) 
        {
            if (start > end) return;

            int middle = (start + end) / 2;
            Add(array[middle]);
            Insert(array, start, middle - 1);
            Insert(array, middle + 1, end);
        }

        public void Add(int x)
        {
            root = Add(root, x);
        }

        private Node Add(Node node, int x)
        {
            if (node == null) return new Node() { Value = x };

            if (x < node.Value)
            {
                node.Left = Add(node.Left, x);
            }
            else if (x > node.Value)
            {
                node.Right = Add(node.Right, x);
            }
            else
            {
                node.Value = x;
            }

            return node;
        }

        public void BuildFromArray(int[] array) 
        {
            root = BuildFromArray(array, 0);
        }

        /// <summary>
        /// Follows the array order.
        /// </summary>
        private Node BuildFromArray(int[] array, int index)
        {
            if (index >= array.Length) return null;

            Node node = new Node() { Value = array[index] };

            int leftIndex = ((index + 1) * 2) - 1;
            int rightIndex = (index + 1) * 2;

            node.Left = BuildFromArray(array, leftIndex);
            node.Right = BuildFromArray(array, rightIndex);

            return node;
        }

        public IEnumerable<IEnumerable<int>> PathsWithSum(int sum)
        {
            var result = new List<List<int>>();
            CheckPathSum(root, sum, 0, new List<Node>(), result);
            return result;
        }

        private void CheckPathSum(Node node, int targetSum, int currentSum, List<Node> currentList, List<List<int>> sumPaths)
        {
            if (node == null) return;

            var removedNodes = new List<Node>();

            //calculate new sum and add current node to path
            int newSum = currentSum + node.Value;
            currentList.Add(node);

            if (newSum > targetSum)
            {
                //remove nodes while newSum is bigger (except current node)
                while (newSum > targetSum && currentList.Count >= 1)
                {
                    //remove from the head
                    var removedNode = currentList[0];
                    newSum -= removedNode.Value;
                    currentList.RemoveAt(0);
                    //insert at head
                    removedNodes.Insert(0, removedNode);
                }
            }


            //check if now the newSum is equal (either initially or by removing nodes)
            if (newSum == targetSum)
            {
                sumPaths.Add(new List<int>(currentList.Select(n => n.Value)));
            }

            //keep going down the tree
            CheckPathSum(node.Left, targetSum, newSum, currentList, sumPaths);
            CheckPathSum(node.Right, targetSum, newSum, currentList, sumPaths);

            //when returning, add back removed nodes
            foreach (var removedNode in removedNodes)
            {
                currentList.Insert(0, removedNode);
            }

            //now remove current node
            currentList.RemoveAt(currentList.Count - 1);
        }

        public void SetNext()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            Node last = root;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                last.Next = node;
                last = node;

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        public int MinHeight()
        {
            if (root == null) return 0;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node first = root;
            int level = 1;

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                if (node.Left == null && node.Right == null)
                {
                    return level;
                }

                if (node == first)
                {
                    level++;
                    first = null;
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                    if (first == null) first = node.Left;
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                    if (first == null) first = node.Right;
                }
            }

            return level;
        }

        public int MaxSumPath()
        {
            if (root == null) return 0;

            int maxSum = int.MinValue;
            var stack = new Stack<Node>();
            var current = root;

            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();

                    int sum = SumPath(current);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }

                    current = current.Right;
                }
            }

            return maxSum;
        }

        private int SumPath(Node node)
        {
            if (node == null) return 0;

            int value = node.Value + Math.Max(SumPath(node.Left), SumPath(node.Right));
            return Math.Max(0, value);
        }

        public static bool IsPreOrder(int[] array)
        {
            var stack = new Stack<int>();
            int root = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                int node = array[i];

                if (node < root)
                {
                    return false;
                }

                while (stack.Count > 0 && stack.Peek() < node)
                {
                    root = stack.Pop();
                }

                stack.Push(node);
            }

            return true;
        }

        public bool IsFull()
        {
            return IsFull(root);
        }

        private bool IsFull(Node root)
        {
            if (root == null) return true;
            else if (root.Left == null && root.Right == null) return true;
            else if (root.Left != null && root.Right != null) return IsFull(root.Left) && IsFull(root.Right);
            else return false;
        }

        public void RemoveWithShortPath(int k)
        {
            int rootLength;
            root = RemoveWithShortPath(root, k, 1, out rootLength);
        }

        //http://www.geeksforgeeks.org/remove-nodes-root-leaf-paths-length-k/
        private Node RemoveWithShortPath(Node node, int k, int level, out int maxLength)
        {
            if (node == null)
            {
                maxLength = level - 1;
                return null;
            }

            int leftLength, rightLength;
            node.Left = RemoveWithShortPath(node.Left, k, level + 1, out leftLength);
            node.Left = RemoveWithShortPath(node.Right, k, level + 1, out rightLength);

            maxLength = Math.Max(leftLength, rightLength);
            return (maxLength >= k) ? node : null;
        }

        private class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Next { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}
