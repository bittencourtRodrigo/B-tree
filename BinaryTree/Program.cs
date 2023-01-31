namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            Tree tree = new Tree();
            do
            {
                Console.Write("Guarde algum INTEIRO na árvore. -> ");
                int value = int.Parse(Console.ReadLine());
                tree.AddNode(value);
            } while (true);
        }
    }
}