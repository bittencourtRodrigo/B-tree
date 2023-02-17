using BinaryTree.TreeModel;

namespace BinaryTree.TreeService
{
    public class TreeServices
    {
        private Tree _tree;

        public TreeServices(Tree tree)
        {
            _tree = tree;
        }

        public void AddNode(string value)
        {
            while (value.Contains(' ')) //Tratamento para evitar entrada de dados iguais.
            {
                value = value.Remove(value.IndexOf(' '), 1);
            }

            if (_tree.Star != null)
            {
                string conf = "";
                Data(ref conf);
                if (conf.Contains(value))
                {
                    throw new Exception("Não foi possível adicionar este valor, ele já existe na árvore.");
                }
            }

            int valueInt = int.Parse(value);
            AddNodeRecursive(ref _tree.Star, valueInt);
        }

        private void AddNodeRecursive(ref Node node, int value) //Percorre a árvore, guiado por regra da mesma. Quando se depara com o nó nulo, quarda o valor que o usuário deseja inserir e returna tudo.
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

        public void Data(ref string stg)
        {
            DataRecursive(ref _tree.Star, ref stg);
        }
        private void DataRecursive(ref Node node, ref string stg) //Percorre toda a árvore amontoando os inteiros encontrados. Eles são armazenados na variável que esta no MAIN e veio por referência.
        {

            if (node == null)
            {
                throw new Exception("Adicione dados antes de vir aqui.");
            }

            if (_tree.Star.Left != null)
            {
                DataRecursive(ref node.Left, ref stg);
                stg += _tree.Star.Value + " ";
            }
            else
            {
                stg += node.Value + " ";
            }
            if (node.Right != null)
            {
                DataRecursive(ref node.Right, ref stg);
            }
        }

        public void Delete(int value) //Ponte suporte para método recursivo.
        {
            _tree.Star = DeleteRecursive(_tree.Star, value);
        }
        private Node DeleteRecursive(Node node, int valor)
        {
            if (node == null) //Percorreu a guia, não encontrou o semelhante do dado inserido pelo usuário, entrará nesta condição, assim, lança uma costom exception.
            {
                throw new Exception("Nó não encontrado.");
            }
            else
            {
                if (node.Value == valor)
                {
                    if (node.Left == null && node.Right == null) //True == é uma folha.
                    {
                        return null; //Seu pai, agora, não mais apontará para algum valor. Seu antigo filho será nulo. O return nulo cairá no respectivo lado que foi chamado, assim alterando o herdeiro.
                    }
                    else
                    {
                        if (node.Left != null && node.Right != null) //True = possui 2 filhos. Este IF alterna o valor do nó que será "deletado" (será apenas trocado o valor) com o valor do nó mais a esquerda da sua árvore direita.
                        {
                            Node find = node.Right; //Entramos na árvore a direita.

                            while (find.Left != null) //Descendo até onde der para a esquerda.
                            {
                                find = find.Left;
                            }

                            node.Value = find.Value; //Trocando valores. Agora a árvore tem um valor fora do padrão em sua estrutura, pois foi alternado o valor de 2 nós. Queremos apagar, de fato, o valor que o usuário deseja, ele encontra-se na árvore da direita (esta árvore tem o node. no nó onde encontramos primeiramente o valor que p usuário deseja apagar) na posição mais a esquerda.
                            find.Value = valor;
                            node.Right = DeleteRecursive(node.Right, valor); //Será passado o valor que o usuário inseriu. E rodar a estrutura novamente.
                            return node;
                        }
                        else //Apagando nó com 1 filho. Guarda-se seu único filho e retorna ele para que o pai do seu pai receba no retorno e defina seu novo filho, que era seu neto.
                        {
                            Node find;

                            if (node.Left != null)
                            {
                                find = node.Left;
                            }
                            else
                            {
                                find = node.Right;
                            }

                            node = null;
                            return find;
                        }
                    }
                }
                else //Aqui onde o caminho é guiado de acordo ao valor passado pelo usuário. 100% regrado pela lei da árvore binaria.
                {
                    if (node.Value > valor)
                    {
                        node.Left = DeleteRecursive(node.Left, valor);
                    }
                    else if (node.Value < valor)
                    {
                        node.Right = DeleteRecursive(node.Right, valor);
                    }
                    return node;
                }
            }
        }
    }
}