using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Microsoft
{
    class GenericTree
    {

        private bool IsSymmetric(Node root)
        {
            int? height = null;
            int? count = null;

            foreach (var node in root.Children)
            {
                //assert height is the same for all
                int nodeHeight = GetHeight(node);
                if (!height.HasValue)
                {
                    height = nodeHeight;
                }
                else if (nodeHeight != height.Value)
                {
                    return false;
                }

                //assert count
                int nodeCount = CountNodes(node);
                if (!count.HasValue)
                {
                    count = nodeCount;
                }
                else if (nodeCount != count.Value)
                {
                    return false;
                }
            }

            return true;
        }

        private int GetHeight(Node node)
        {
            int maxHeight = 0;
            foreach (var child in node.Children)
            {
                maxHeight = Math.Max(maxHeight, GetHeight(child));
            }

            return maxHeight + 1;
        }

        private int CountNodes(Node node)
        {
            int count = 0;
            foreach (var child in node.Children)
            {
                count += CountNodes(child);
            }

            return node.Children.Count() + count;
        }

        private void GetCountAndHeight(Node node, out int count, out int height)
        {
            count = node.Children.Count;
            height = 0;
            foreach (var child in node.Children)
            {
                int childHeight;
                int childCount;
                GetCountAndHeight(child, out childCount, out childHeight);

                height = Math.Max(height, childHeight);
                count += childCount;
            }

            height++;//need to count the current level
        }


        class Node
        {
            public List<Node> Children { get; set; }
        }
    }

}
