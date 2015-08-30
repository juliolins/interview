using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class TreeCreateLinkedLists
    {

        public static void Test()
        {
            PrintList(CreateLevelLists(BuildTree()));

        }

        public static List<List<TreeNode>> CreateLevelLists(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);


            List<List<TreeNode>> superList = new List<List<TreeNode>>();
            List<TreeNode> currentList = new List<TreeNode>();
            superList.Add(currentList);
            TreeNode levelFirst = null;

            while (queue.Count > 0)
            {
                //process one code
                TreeNode node = queue.Dequeue();

                //enqueue children
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);

                if (levelFirst == null || levelFirst == node)
                {
                    //current node is first on the level
                    //create a new list
                    if (levelFirst == node)
                    {
                        currentList = new List<TreeNode>();
                        superList.Add(currentList);
                    }

                    //properly set the levelFirst
                    if (node.left != null)
                    {
                        levelFirst = node.left;
                    }
                    else if (node.right != null)
                    {
                        levelFirst = node.right;
                    }
                    else
                    {
                        //FIXME!!! first doesn't have children, need to make the next children the next 
                        //if node doesn't have children, the next node will be the first on the level                        
                        levelFirst = null;
                    }

                }

                //add the node to the current list
                currentList.Add(node);
            }


            return superList;
        }

        public static void PrintList(List<List<TreeNode>> superList)
        {
            foreach (List<TreeNode> list in superList)
            {
                Console.WriteLine();
                foreach (TreeNode item in list)
                {
                    Console.Write(item.data + " ");
                }
            }
        }

        public static TreeNode BuildTree()
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

            return a;
        }
    }
}
