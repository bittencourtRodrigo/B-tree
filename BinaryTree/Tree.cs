using System;
namespace BinaryTree
{
    public class Tree
    {
        public Node Top;
        public Tree()
        {
        }
        public async void AddNodeAsync(int value)
        {
            AddNodeRecursive(ref Top, value);
        }
        private void AddNodeRecursive(ref Node node, int value)
        {
            if (node == null)
            {
                Node newNode = new Node(value);
                node = newNode;
                return;
            }

            if (value < node.Value)
            {
                AddNodeRecursive(ref node.Left, value);
            }

            if (value >= node.Value)
            {
                AddNodeRecursive(ref node.Right, value);
            }
        }
        public void GetDataTree(Node node, ref string stg)
        {
            if (node.Left != null)
            {
                GetDataTree(node.Left, ref stg);
                stg += node.Value + " ";
            }
            else
            {
                stg += node.Value + " ";
            }
            if (node.Right != null)
            {
                GetDataTree(node.Right, ref stg);
            }
        }
    }
}
