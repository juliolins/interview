using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    class TreeNextSibling
    {
        public static void Test()
        {
            Build();
        }

        public static TreeNode Build()
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
            b.parent = c.parent = a;

            b.left = d;
            b.right = e;
            d.parent = e.parent = b;

            c.left = f;
            c.right = g;
            f.parent = g.parent = c;

            d.left = h;
            d.right = i;
            h.parent = i.parent = d;

            e.left = j;
            e.right = k;
            j.parent = k.parent = e;

            f.left = l;
            f.right = m;
            l.parent = m.parent = f;

            g.left = n;
            g.right = o;
            n.parent = o.parent = g;

            Console.WriteLine(string.Format("Next {0} = {1}", d.data, FindNext(d).data));


            return a;
        }

        public static TreeNode FindNext(TreeNode node)
        {
            int levelUp = 0;

            TreeNode parent = node.parent;

            while (true)
            {
                //node is root
                if (parent == null) return null;

                if (levelUp == 0)
                {
                    if (parent.left != null && parent.left != node && parent.right != node)//can't be left brother
                    {
                        return parent.left;
                    }

                    if (parent.right != null && parent.right != node)
                    {
                        return parent.right;
                    }

                    levelUp++;
                    parent = parent.parent;
                }
                else
                {
                    //go down a level
                    if (parent.right != null)
                    {
                        parent = parent.right;
                        levelUp--;
                    }
                    else
                    {
                        //increase another level
                        parent = parent.parent;
                        levelUp++;
                    }
                }

            } 
        }
    }
}
