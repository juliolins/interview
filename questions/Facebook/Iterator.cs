using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Facebook
{
    public class TestTreeWithIterator
    {
        public static void Test() 
        {
            var test = TreeWithIterator<int, int>.MakeTestTree();

            var it = test.GetIterator();

            while (it.HasNext())
            {
                Console.WriteLine(it.Next());
            }
        }
    }


    public class TreeWithIterator<TKey, TValue>
    {
        public static TreeWithIterator<int, int> MakeTestTree()
        {
            var tree = new TreeWithIterator<int, int>();

            tree.root = new TreeWithIterator<int, int>.Node() { Key = 5, Value = 5 };
            tree.root.Left = new TreeWithIterator<int, int>.Node() { Key = 3, Value = 3 };
            tree.root.Left.Left = new TreeWithIterator<int, int>.Node() { Key = 2, Value = 2 };
            tree.root.Left.Left.Left = new TreeWithIterator<int, int>.Node() { Key = 1, Value = 1 };
            tree.root.Left.Right = new TreeWithIterator<int, int>.Node() { Key = 4, Value = 4 };

            tree.root.Right = new TreeWithIterator<int, int>.Node() { Key = 10, Value = 10 };
            tree.root.Right.Left = new TreeWithIterator<int, int>.Node() { Key = 8, Value = 8 };
            tree.root.Right.Left.Right = new TreeWithIterator<int, int>.Node() { Key = 9, Value = 9 };
            tree.root.Right.Right = new TreeWithIterator<int, int>.Node() { Key = 11, Value = 11 };
            
            return tree;
        }


        private Node root;

        public TreeIterator<TValue> GetIterator()
        {
            return new TheIterator2(root);
        }

        /// <summary>
        /// Version using extra space to store visited nodes.
        /// </summary>
        class TheIterator : TreeIterator<TValue>
        {
            private Stack<Node> stack = new Stack<Node>();
            private Dictionary<Node, bool> visitedRight = new Dictionary<Node,bool>();

            public TheIterator(Node root)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
            }

            public bool HasNext()
            {
                return stack.Any();
            }

            public TValue Next()
            {
                Node current = stack.Peek();

                if (visitedRight.ContainsKey(current))
                {
                    //pop current and then return
                    return stack.Pop().Value;
                }
                else //haven't visited this yet, need to go right, then left
                {
                    visitedRight[current] = true;
                    current = current.Right;

                    while (current != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }

                    //current is the left node
                    //re-run the same logic for the left node
                    return Next();
                }
            }
        }

        /// <summary>
        /// Version without using extra space.
        /// </summary>
        class TheIterator2 : TreeIterator<TValue>
        {
            private Stack<Node> stack = new Stack<Node>();

            public TheIterator2(Node root)
            {
                while (root != null)
                {
                    if (root.Right != null) stack.Push(root.Right);
                    stack.Push(root);
                    root = root.Left;
                }
            }

            public bool HasNext()
            {
                return stack.Any();
            }

            public TValue Next()
            {
                Node current = stack.Pop();

                if (current.Right == null || stack.Count == 0 || current.Right != stack.Peek())
                {
                    //pop current and then return
                    return current.Value;
                }
                else //haven't visited this yet, need to go right, then left
                {
                    //take right child off the stack
                    var right = stack.Pop();
                    
                    //put current
                    stack.Push(current);

                    //now navigate left from the right child on
                    current = right;
                    while (current != null)
                    {
                        if (current.Right != null) stack.Push(current.Right);
                        stack.Push(current);
                        current = current.Left;
                    }

                    //current is the left node
                    //re-run the same logic for the left node
                    return Next();
                }
            }
        }


        class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }

    public interface TreeIterator<T>
    {
        bool HasNext();
        T Next();
    }

}
