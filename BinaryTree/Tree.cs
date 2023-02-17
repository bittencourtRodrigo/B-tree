using System;
namespace BinaryTree
{
    public class Tree
    {
        public Node Top;
        public void AddNode(int value)
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


        public void FindNode(int valor)
        {
            Node nodeWBDelete = Top; //WB = will be
            Node nodeFindReplace; //terá o nó que será trocado.
            Node father;
            while (true) //nodeWBDelete -> saíra com o endereço do nó que será deletado.
            {


                if (nodeWBDelete.Left.Value == valor || nodeWBDelete.Right.Value == valor)
                {
                    father = nodeWBDelete;
                    if (nodeWBDelete.Left.Value == valor)
                    {
                        nodeWBDelete = nodeWBDelete.Left;
                        break;
                    }
                    else if (nodeWBDelete.Right.Value == valor)
                    {
                        nodeWBDelete = nodeWBDelete.Right;
                        break;
                    }
                }
                else if (nodeWBDelete.Value > valor)
                {
                    nodeWBDelete = nodeWBDelete.Left;
                }
                else if (nodeWBDelete.Value < valor)
                {
                    nodeWBDelete = nodeWBDelete.Right;
                }
            }
            
             //f = 90
            nodeFindReplace = nodeWBDelete.Right; //desce 1 para direita

            while (nodeFindReplace.Left != null)
            {
                if (nodeFindReplace.Left.Left == null)
                {
                    break;
                }
                nodeFindReplace = nodeFindReplace.Left;
            }

            if (father.Left.Value == valor)
            {
                if (nodeFindReplace.Left != null)
                {
                    father.Left.Value = nodeFindReplace.Left.Value;
                }
                else
                {
                    father.Left.Value = nodeFindReplace.Value;
                }
            }
            else if (father.Right.Value == valor && nodeFindReplace.Left.Value != null)
            {
                if (nodeFindReplace.Right != null)
                {
                    father.Right.Value = nodeFindReplace.Left.Value;
                }
                else
                {
                    father.Right.Value = nodeFindReplace.Value;
                }
            }

            nodeFindReplace.Left = null;

        }
        /*
        public void DeleteNode(Node node)
        {
            Node nodeRight = new Node();

            if (node.Right != null)
            {
                nodeRight = node.Right;
            }
            if (node.Left != null)
            {
                while (nodeRight.Left.Left != null)
                {
                    nodeRight = nodeRight.Left;
                }
            }
            node = nodeRight.Left;
            if (nodeRight != null)
            {
                if (nodeRight.Right != null)
                {
                    nodeRight = nodeRight.Right;
                }
                else
                {
                    nodeRight.Value = null;
                }
            }
        */
    }
}
