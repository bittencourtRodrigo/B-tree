using System;
namespace BinaryTree
{
    public class Tree
    {
        private Node _top;
        public Tree()
        {
        }
        public void AddNode(int value)
        {
            Add(ref _top, value);
        }
        private void Add(ref Node node, int value)
        {
            if (node == null)
            {
                Node newNode = new Node(value);
                node = newNode;
                return;
            }

            if (value < node.Value)
            {
                Add(ref node.Left, value);
            }

            if (value >= node.Value)
            {
                Add(ref node.Right, value);
            }
        }
        public void Print(Node node, ref string stg)
        {
            try
            {
                if (node.Left != null)
                {
                    Print(node.Left, ref stg);
                    stg += node.Value + " ";
                }
                else
                {
                    stg += node.Value + " ";
                }
                if (node.Right != null)
                {
                    Print(node.Right, ref stg);
                }
            }
            catch (Exception)
            {
                throw new Exception("Talvez você tenha esquecido algo.");
            }
        }
    }
}
