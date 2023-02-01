namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            Tree tree = new Tree();
            do
            {
                Console.WriteLine("A -> Adicionar dados(inteiros) na árvore.");
                Console.WriteLine("B -> Imprimir dados.");
                Console.WriteLine("C -> Salvar dados em TXT.");
                Console.WriteLine("D -> Sair.");
                Console.Write("Sua escolha: ");
                string opc = Console.ReadLine().ToUpper();
                Console.Clear();
                switch (opc)
                {
                    case "A":
                        try
                        {
                            Console.Write("Quantos números inteiros quer adicionar? -> ");
                            int opc2 = int.Parse(Console.ReadLine());
                            for (int i = 0; i < opc2; i++)
                            {
                                Console.Write($"{i}º: ");
                                int value = int.Parse(Console.ReadLine());
                                tree.AddNodeAsync(value);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("A última entrada não foi guardada.");
                            Console.WriteLine("Erro: " + e.Message);
                        }
                        break;
                    case "B":
                        if (tree.Top != null)
                        {
                            string dat = "";
                            tree.GetDataTree(tree.Top, ref dat);
                            Console.WriteLine($"Dados: {dat}");
                        }
                        break;
                    case "C":
                        if (tree.Top != null)
                        {
                            string data = "";
                            tree.GetDataTree(tree.Top, ref data);
                            FileSave.SaveTxt(data);
                            Console.WriteLine(@"Salvo na pasta: C:\Arquivos Arvore Binaria\");
                        }
                        break;
                    case "D":
                        return;
                }
                Console.WriteLine("Ação concluída. Aperte alguma tecla para voltar ao menu.");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
    }
}