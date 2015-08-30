using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class BST_Test
    {
        public static void Test()
        {
            BST<int, string> tree = new BST<int, string>();

            tree.Add(1, "Julio ");
            tree.Add(2, "Cesar");
            tree.Add(3, "Dos ");
            tree[2] = "Cesar ";
            tree.Add(4, "Santos ");
            tree.Add(5, "Lins");

            //tree.Remove(3);

            //foreach (string name in tree.Values)
            //{
            //    Console.Write(name);
            //}
            //Console.WriteLine();


            //tree[3] = "Dos ";

            //foreach (string name in tree.ValuesNoStack)
            //{
            //    Console.Write(name);
            //}

            //Console.WriteLine();

            //foreach (int key in tree.GetKeyRange(2, 4))
            //{
            //    Console.Write(tree[key]);
            //}
            //Console.WriteLine();

            //Console.WriteLine("tree.Rank(1) = " + tree.Rank(1));

            Console.WriteLine(tree.FindCommonAncestor(1, 5));
        }
    }


    public class BST<T, U> where T : IComparable
    {
        private BSTNode<T, U> root = null;

        public void Add(T key, U value)
        {
            BSTNode<T, U> node = new BSTNode<T, U>(key, value);
            node.Color = BSTNode<T, U>.RED;
            root = DoAdd(root, node, false);
        }


        public IList<U> Values
        {
            get
            {
                List<U> values = new List<U>();
                Stack<BSTNode<T, U>> stack = new Stack<BSTNode<T, U>>();

                BSTNode<T, U> current = root;

                while (current != null || stack.Count > 0)
                {
                    if (current == null)
                    {
                        //process some parent
                        current = stack.Pop();
                        values.Add(current.Value);

                        //move to right child of the parent
                        current = current.Right;
                    }
                    else
                    {
                        //push the parent
                        stack.Push(current);

                        //go left
                        current = current.Left;
                    }
                }

                return values;
            }
        }


        public IList<U> ValuesNoStack
        {
            get
            {
                List<U> values = new List<U>();
                BSTNode<T, U> current = root;

                while (current != null)
                {
                    if (current.Left == null)
                    {
                        values.Add(current.Value);
                        current = current.Right;
                    }
                    else
                    {
                        BSTNode<T, U> pivot = current.Left;
                        while (pivot.Right != null && pivot.Right != current)
                        {
                            pivot = pivot.Right;
                        }

                        if (pivot.Right == current)
                        {
                            //process current
                            values.Add(current.Value);

                            //undo previously added pointer from pivot to current
                            pivot.Right = null;

                            //processed parent, move right
                            current = current.Right;
                        }
                        else
                        {
                            //add a new pointer from pivot.Right to current
                            pivot.Right = current;
                            
                            //go left
                            current = current.Left;
                        }
                    }
                }

                return values;
            }//close get
        }

        private BSTNode<T, U> DoAdd(BSTNode<T, U> current, BSTNode<T, U> node, bool replaceValue)
        {
            if (current == null)
            {
                return node;
            }

            int compare = node.Key.CompareTo(current.Key);

            if (compare < 0)
            {
                current.Left = DoAdd(current.Left, node, replaceValue);
            }
            else if (compare > 0)
            {
                current.Right = DoAdd(current.Right, node, replaceValue);
            }
            else //compare == 0, same key
            {
                if (!replaceValue)
                {
                    throw new ArgumentException("Key already exists: " + node.Key);
                }
                else
                {
                    current.Value = node.Value;
                }
            }

            return CheckBalance(current);
        }

        public U this[T key]
        {
            get
            {
                return Find(key);
            }
            set
            {
                Put(key, value);
            }
        }

        private U Find(T key)
        {
            BSTNode<T, U> current = root;


            while (current != null)
            {
                int compare = key.CompareTo(current.Key);

                if (compare < 0)
                {
                    current = current.Left;
                }
                else if (compare > 0)
                {
                    current = current.Right;
                }
                else //compare == 0
                {
                    return current.Value;
                }
            }

            throw new KeyNotFoundException();
        }

        private void Put(T key, U value)
        {
            BSTNode<T, U> node = new BSTNode<T, U>(key, value);
            root = DoAdd(root, node, true);
        }

        public void Remove(T key)
        {
            root = DoRemove(root, key);
        }

        private BSTNode<T, U> DoRemove(BSTNode<T, U> current, T key)
        {
            if (current == null)
            {
                return null;
            }

            int compare = key.CompareTo(current.Key);

            if (compare < 0)
            {
                current.Left = DoRemove(current.Left, key);
            }
            else if (compare > 0)
            {
                current.Right = DoRemove(current.Right, key);
            }
            else //found the node to remove
            {
                if (current.Left == null && current.Right == null)
                {
                    //simply make the parent point to null
                    return null;
                }
                else if (current.Left == null)
                {
                    //if left is null, return right
                    return current.Right;
                }
                else if (current.Right == null)
                {
                    //if right is null, return left
                    return current.Left;
                }
                else//neighther is null, so...
                {
                    //find min node of the right side
                    BSTNode<T, U> min = GetMin(current.Right);

                    //delete min from its position
                    current.Right = DoRemove(current.Right, min.Key);

                    //re-add min node as the current node
                    min.Left = current.Left;
                    min.Right = current.Right;
                    min.Color = BSTNode<T, U>.RED;

                    //return min to the parent
                    return CheckBalance(min);
                }

            }

            return current;
        }

        public U FindCommonAncestor(T lowKey, T highKey)
        {
            return DoFindCommonAncestor(lowKey, highKey, root).Value;
        }

        private BSTNode<T, U> DoFindCommonAncestor(T lowKey, T highKey, BSTNode<T, U> root)
        {
            int compareLow = root.Key.CompareTo(lowKey);
            int compareHigh = root.Key.CompareTo(highKey);

            //if root.Key >= lowKey && root.Key <= highKey
            if (compareLow >= 0 && compareHigh <= 0)
            {
                return root;
            }
            //key keys are to the right
            else if (compareLow <= 0 && compareHigh <= 0)
            {
                return DoFindCommonAncestor(lowKey, highKey, root.Right);
            }
            //key keys are to the right
            else if (compareLow >= 0 && compareHigh >= 0)
            {
                return DoFindCommonAncestor(lowKey, highKey, root.Left);
            } 
            else 
            {
                throw new KeyNotFoundException();
            }
        }

        public IList<T> GetKeyRange(T lowKey, T highKey)
        {
            List<T> list = new List<T>();

            DoKeyRange(root, lowKey, highKey, list);

            return list;
        }

        private void DoKeyRange(BSTNode<T, U> node, T lowKey, T highKey, IList<T> list)
        {
            if (node == null)
            {
                return;
            }

            int compLow = node.Key.CompareTo(lowKey);
            int compHigh = node.Key.CompareTo(highKey);

            //if node is greater than low, move left because left sub tree 
            // can still be greater than low
            if (compLow > 0)
            {
                DoKeyRange(node.Left, lowKey, highKey, list);
            }

            //in between, so add current node
            if (compLow >= 0 && compHigh <= 0)
            {
                list.Add(node.Key);
            }

            //if node is smaller than high, move left because right sub tree 
            // can still be smaller than high
            if (compHigh < 0)
            {
                DoKeyRange(node.Right, lowKey, highKey, list);
            }
        }

        public int Rank(T key)
        {
            int rank = -1;

            BSTNode<T, U> current = root;
            Stack<BSTNode<T, U>> stack = new Stack<BSTNode<T,U>>();

            while (current != null || stack.Count > 0)
            {
                if (current == null)
                {
                    current = stack.Pop();

                    rank++; //processed

                    if (current.Key.CompareTo(key) == 0)
                    {
                        return rank;
                    }

                    current = current.Right;
                }
                else
                {
                    stack.Push(current);
                    current = current.Left;
                }
            }

            throw new KeyNotFoundException();
        }

        public T Ceiling(T key)
        {
            BSTNode<T, U> current = root;

            T ceiling = default(T);

            while (current != null)
            {
                int comp = current.Key.CompareTo(key);

                //current is larger, save ceiling and move left
                if (comp >= 0)
                {
                    ceiling = current.Key;
                    current = current.Left;
                }
                else
                {
                    //current is smaller, move right
                    current = current.Right;
                }
            }

            return ceiling;
        }

        public U FindNthElement(int n)
        {
            if (n == 0)
            {
                return default(U);
            }

            BSTNode<T, U> current = root;
            Stack<BSTNode<T, U>> stack = new Stack<BSTNode<T, U>>();

            while (current != null || stack.Count > 0)
            {
                if (current == null)
                {
                    current = stack.Pop();

                    n--; //processed

                    if (n == 0)
                    {
                        return current.Value;
                    }

                    current = current.Right;
                }
                else
                {
                    stack.Push(current);
                    current = current.Left;
                }
            }

            return default(U);
        }

        private BSTNode<T, U> CheckBalance(BSTNode<T, U> node)
        {
            if (!IsRed(node.Left) && IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && (node.Left != null) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                node = FlipColor(node);
            }

            return node;
        }

        private bool IsRed(BSTNode<T, U> node)
        {
            return node != null && node.Color == BSTNode<T, U>.RED;
        }

        private BSTNode<T, U> RotateLeft(BSTNode<T, U> node)
        {
            BSTNode<T, U> newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            newRoot.Color = node.Color;
            node.Color = BSTNode<T, U>.RED;
            return newRoot;
        }

        private BSTNode<T, U> RotateRight(BSTNode<T, U> node)
        {
            BSTNode<T, U> newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            newRoot.Color = node.Color;
            node.Color = BSTNode<T, U>.RED;
            return newRoot;
        }

        private BSTNode<T, U> FlipColor(BSTNode<T, U> node)
        {
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
            return node;
        }

        private BSTNode<T, U> GetMin(BSTNode<T, U> root)
        {
            while (root.Left != null)
            {
                root = root.Left;
            }

            return root;
        }
    }

    class BSTNode<T, U> where T : IComparable
    {
        public const bool BLACK = false;
        public const bool RED = true;

        public T Key { get; set; }
        public U Value { get; set; }

        public BSTNode<T, U> Left { get; set; }
        public BSTNode<T, U> Right { get; set; }

        public bool Color { get; set; }

        public BSTNode(T key, U value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
