using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.SymbolTables
{
    public static class TestTree
    {
        public static void Test()
        {
            var bst = new BinarySearchTree<int, int>();

            bst[1] = 10;
            bst[2] = 20;
            bst[3] = 30;
            bst[5] = 50;
            bst[6] = 60;
            bst[8] = 80;
            bst[9] = 90;

            Console.WriteLine("Max = " + bst.Max());
            Console.WriteLine("Min = " + bst.Min());
            Console.WriteLine("Floor(7) = " + bst.Floor(7));
            Console.WriteLine("Ceiling(4) = " + bst.Ceiling(4));
            Console.WriteLine("Rank(6) = " + bst.Rank(6));
            Console.WriteLine("RankIteractive(6) = " + bst.RankIteractive(6));

            Console.WriteLine("Values = " + bst.Values().Print());
            Console.WriteLine("Select(5) = " + bst.SelectOn(5));

            //bst.Delete(5);
            Console.WriteLine("Values = " + bst.Values().Print());
            Console.WriteLine("SelectOn(5) = " + bst.SelectOn(5));
            Console.WriteLine("Select(5) = " + bst.Select(5));

            Console.WriteLine("Keys(2, 6) = " + bst.Keys(2, 6).Print());
        }
    }


    public class BinarySearchTree<TKey, TValue> where TKey : IComparable
    {
        private Node<TKey, TValue> root;

        public BinarySearchTree()
        {

        }

        public void Put(TKey key, TValue value)
        {
            root = Put(root, key, value);
        }

        private Node<TKey, TValue> Put(Node<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null) return new Node<TKey, TValue>() { Key = key, Value = value, Color = Color.Red, Size = 1};

            int comparison = key.CompareTo(node.Key);
            if (comparison < 0)
            {
                node.Left = Put(node.Left, key, value);
            }
            else if (comparison > 0)
            {
                node.Right = Put(node.Right, key, value);
            }
            else //equals
            {
                node.Value = value;
            }

            Resize(node);

            return CheckBalenced(node);
        }

        private int Size(Node<TKey, TValue> node) 
        {
            if (node == null) return 0;
            else return node.Size;
        }

        private void Resize(Node<TKey, TValue> node) 
        {
            if (node == null) return;
            node.Size = 1 + Size(node.Left) + Size(node.Right);
        }

        private Node<TKey, TValue> CheckBalenced(Node<TKey, TValue> node)
        {
            if (IsRed(node.Right) && !IsRed(node.Left)) node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left.Left)) node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right)) FlipColors(node);

            return node;
        }

        private Node<TKey, TValue> RotateLeft(Node<TKey, TValue> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            Resize(node);
            newNode.Left = node;
            Resize(newNode);
            newNode.Color = node.Color;
            node.Color = Color.Red;
            return newNode;
        }

        private Node<TKey, TValue> RotateRight(Node<TKey, TValue> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            Resize(node);
            newNode.Right = node;
            Resize(newNode);
            newNode.Color = node.Color;
            node.Color = Color.Red;
            return newNode;
        }

        private void FlipColors(Node<TKey, TValue> node)
        {
            node.Color = Color.Red;
            node.Left.Color = Color.Black;
            node.Right.Color = Color.Black;
        }

        public TValue this[TKey key]
        {
            get
            {
                var current = root;
                while (current != null)
                {
                    int comparison = key.CompareTo(current.Key);

                    if (comparison < 0)
                    {
                        current = current.Left;
                    }
                    else if (comparison > 0)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        return current.Value;
                    }
                }

                return default(TValue);
            }

            set
            {
                Put(key, value);
            }
        }

        public TValue Max()
        {
            TValue result = default(TValue);
            var current = root;

            while (current != null)
            {
                result = current.Value;
                current = current.Right;
            }

            return result;
        }

        public TValue Min()
        {
            TValue result = default(TValue);
            var current = root;

            while (current != null)
            {
                result = current.Value;
                current = current.Left;
            }

            return result;
        }

        public TKey Floor(TKey key)
        {
            var floorKey = default(TKey);
            var current = root;

            while (current != null)
            {
                int comparison = current.Key.CompareTo(key);
                if (comparison < 0)
                {
                    //keep largest smaller key so far
                    floorKey = current.Key;
                    current = current.Right;
                }
                else if (comparison > 0)
                {
                    current = current.Left;
                }
                else //if we find a match, need to break
                {
                    floorKey = key;
                    break;
                }
            }

            return floorKey;
        }

        public TKey Ceiling(TKey key)
        {
            var ceiling = default(TKey);
            var current = root;

            while (current != null)
            {
                int comparison = current.Key.CompareTo(key);
                if (comparison > 0)
                {
                    //keep largest smaller key so far
                    ceiling = current.Key;
                    current = current.Left;
                }
                else if (comparison < 0)
                {
                    current = current.Right;
                }
                else //if we find a match, need to break
                {
                    ceiling = key;
                    break;
                }
            }

            return ceiling;
        }

        public int Rank(TKey key)
        {
            return Rank(key, root);
        }

        private int Rank(TKey key, Node<TKey, TValue> node)
        {
            if (node == null) return 0;

            int comparison = node.Key.CompareTo(key);

            //if node is smaller, then return 1 + plus both sides
            if (comparison < 0)
            {
                return 1 + Rank(key, node.Right) + Rank(key, node.Left);
            }
            else
            {
                //return only left side since right side has all larger elements
                return Rank(key, node.Left);
            }
        }

        public int RankIteractive(TKey key)
        {
            int count = 0;
            var stack = new Stack<Node<TKey, TValue>>();
            if (root != null) stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                int comparison = current.Key.CompareTo(key);

                if (comparison < 0)
                {
                    count++;
                    if (current.Left != null) stack.Push(current.Left);
                    if (current.Right != null) stack.Push(current.Right);
                }
                else
                {
                    if (current.Left != null) stack.Push(current.Left);
                }
            }

            return count;
        }

        public IEnumerable<TValue> Values()
        {
            var result = new List<TValue>();
            ValuesNoStack(result);
            return result;
        }

        private void ValuesRecursive(Node<TKey, TValue> node, List<TValue> values)
        {
            if (node == null) return;

            ValuesRecursive(node.Left, values);
            values.Add(node.Value);
            ValuesRecursive(node.Right, values);
        }

        private void ValuesIteractive(List<TValue> values)
        {
            var stack = new Stack<Node<TKey, TValue>>();
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
                    values.Add(current.Value);
                    current = current.Right;
                }
            }
        }

        private void ValuesNoStack(List<TValue> values)
        {
            var current = root;

            while (current != null)
            {
                //left there's no left subtree, process this node and move right
                if (current.Left == null)
                {
                    values.Add(current.Value);
                    current = current.Right;
                }
                else
                {
                    //if there's a left subtree, either this node has already been stepped by or it's the first time
                    //find the pilot (the rightmost node in current's left subtree)
                    var pilot = current.Left;
                    while (pilot.Right != null && pilot.Right != current)
                    {
                        pilot = pilot.Right;
                    }

                    //with the pilot, not check if it's right child is pointing to the current which means current has already
                    //been stepped by and needs to be processed now
                    if (pilot.Right == current)
                    {
                        //process current since this is the second time it's stepped by
                        values.Add(current.Value);

                        //clean pilot right pointer
                        pilot.Right = null;

                        //move right
                        current = current.Right;
                    }
                    else
                    {
                        //pilot.right == null, which means this is the first time current is stepped by
                        //Make current as right child of pivot, and move left
                        pilot.Right = current;
                        current = current.Left;
                    }
                }
            }

        }

        //return all keys in the inclusive internal
        public IEnumerable<TKey> Keys(TKey low, TKey high)
        {
            var keys = new List<TKey>();
            var stack = new Stack<Node<TKey, TValue>>();
            var current = root;
            bool foundLow = false;

            //1st: first low key
            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    //go left if there's a left sub-tree (pre-order)
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    //process stack
                    current = stack.Pop();
                    
                    if (!foundLow && current.Key.CompareTo(low) == 0)
                    {
                        foundLow = true;
                    }

                    //if already found the start, add to result set
                    if (foundLow)
                    {
                        keys.Add(current.Key);

                        //if reached high, stop
                        if (current.Key.CompareTo(high) == 0)
                        {
                            break;
                        }
                    }

                    current = current.Right;
                }
            }

            return keys;

        }

        public TKey Select(int k)
        {
            var current = root;

            while (current != null)
            {
                int leftAndSelfSize = Size(current) - Size(current.Right);

                if (leftAndSelfSize == k)
                {
                    //found the match
                    return current.Key;
                }
                else if (leftAndSelfSize > k)
                {
                    //if there are more items to the left, move left
                    current = current.Left;
                }
                else
                {
                    //there aren't enough items on the left, the Kth key is to the right
                    current = current.Right;
                    k = k - leftAndSelfSize;
                }
            }

            return default(TKey);
        }

        public TKey SelectOn(int k)
        {
            var stack = new Stack<Node<TKey, TValue>>();
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

                    if (--k == 0)
                    {
                        return current.Key;
                    }

                    current = current.Right;
                }
            }

            return default(TKey);
        }

        public void Delete(TKey key)
        {
            root = Delete(root, key);
        }

        private Node<TKey, TValue> Delete(Node<TKey, TValue> node, TKey key)
        {
            if (node == null) return null;

            int comparison = key.CompareTo(node.Key);
            if (comparison < 0)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (comparison > 0)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                //found a match, need to delete

                return DoDeletion(node);
            }

            return node;
        }

        private Node<TKey, TValue> DoDeletion(Node<TKey, TValue> node)
        {
            Node<TKey, TValue> result;

            //base case, leaf
            if (node.Left == null && node.Right == null)
            {
                result = null;
            }
            else if (node.Left != null && node.Right == null)
            {
                result = node.Left;
            }
            else if (node.Left == null & node.Right != null)
            {
                result = node.Right;
            }
            else
            {
                var successor = FindMin(node.Right);
                successor.Right = Delete(node.Right, successor.Key);
                successor.Left = node.Left;
                result = successor;
            }

            Resize(result);
            return result;
        }

        private bool IsRed(Node<TKey, TValue> node)
        {
            return (node != null && node.Color == Color.Red);
        }

        private Node<TKey, TValue> FindMin(Node<TKey, TValue> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        internal enum Color { Red, Black };

        private class Node<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Color Color { get; set; }
            public int Size { get; set; }
            public Node<TKey, TValue> Left { get; set; }
            public Node<TKey, TValue> Right { get; set; }
        }
    }
}
