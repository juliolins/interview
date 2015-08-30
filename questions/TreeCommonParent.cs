using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class TreeCommonParent
    {
        public static void Test()
        {
            TreeNode a = new TreeNode(), b = new TreeNode(), c = new TreeNode(), d = new TreeNode(), e = new TreeNode(), f = new TreeNode(), g = new TreeNode();
            TreeNode h = new TreeNode(), i = new TreeNode(), j = new TreeNode(), k = new TreeNode(), l = new TreeNode(), m = new TreeNode(), n = new TreeNode(), o = new TreeNode();

            a.data = "A";
            b.data = "B";
            c.data = "C";
            d.data = "D";
            e.data = "E";
            f.data = "F";
            g.data = "G";
            h.data = "H";
            i.data = "I";
            j.data = "J";
            k.data = "K";
            l.data = "L";
            m.data = "M";
            n.data = "N";
            o.data = "O";

            a.left = b;
            a.right = c;

            b.left = d;
            b.right = e;

            c.left = f;
            c.right = g;

            d.left = h;
            d.right = i;

            e.left = j;
            e.right = k;

            f.left = l;
            f.right = m;

            g.left = n;
            g.right = o;

            bool foundParent;
            TreeNode common = FindParent(a, l, m, out foundParent);

            Console.WriteLine("Common parent: " + common.data);
        }


        public static TreeNode FindParent(TreeNode node, TreeNode nodeOne, TreeNode nodeTwo, out bool foundParent)
        {
            foundParent = false;

            if (node == null)
            {
                return null;
            }
            else if (node == nodeOne || node == nodeTwo)
            {
                return node;
            }
            else 
              //if (
              //(FindParent(node.left, nodeOne, nodeTwo, out found) == nodeOne && FindParent(node.right) == nodeTwo) ||
              //(FindParent(node.right) == nodeOne && FindParent(node.left) == nodeTwo)
              //)
            {
                //if it as already been found on the left side
                TreeNode leftTree = FindParent(node.left, nodeOne, nodeTwo, out foundParent);
                if (foundParent) return leftTree;

                //if it as already been found on the right side
                TreeNode rightTree = FindParent(node.right, nodeOne, nodeTwo, out foundParent);
                if (foundParent) return rightTree;

                //if this is the common parent node
                if ((leftTree == nodeOne && rightTree == nodeTwo) || (rightTree == nodeOne && leftTree == nodeTwo))
                {
                    foundParent = true;
                    return node;
                }
                else if (leftTree == nodeOne || leftTree == nodeTwo)
                {
                    return leftTree;
                }
                else if (rightTree == nodeOne || rightTree == nodeTwo)
                {
                    return rightTree;
                }
            }

            return null;
        }

    }


    public class TreeNode
    {
        public string data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;
    }
}
