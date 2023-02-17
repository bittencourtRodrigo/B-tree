namespace BinaryTree.TreeModel
{
    public class Node
    {
        public int? Value;
        public Node Right;
        public Node Left;

        public Node()
        {
        }

        public Node(int value)
        {
            Value = value;
            Right = null;
            Left = null;
        }
    }
}