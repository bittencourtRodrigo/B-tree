using BinaryTree.Services;
using BinaryTree.TreeModel;
using BinaryTree.TreeService;
namespace BinaryTree
{
    class Program
    {


        static void Main()
        {
            Tree tree = new Tree();
            TreeServices _treeservices = new TreeServices(tree);
           
            do
            {
                string dataTree = "";
                Console.WriteLine("A -> Adicionar.");
                Console.WriteLine("B -> Imprimir no console.");
                Console.WriteLine("C -> Salvar em TXT.");
                Console.WriteLine("D -> Apagar.");
                Console.WriteLine("E -> Cair fora.");
                Console.Write("Sua escolha: ");
                string opc = Console.ReadLine().ToUpper();
                Console.Clear();
                
                switch (opc)
                {
                    case "A":
                        try
                        {
                            Console.Write("(Número inteiro): ");
                            string inputInt = Console.ReadLine();
                            _treeservices.AddNode(inputInt);
                            Console.WriteLine("\nSucesso!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erro: {0}", e.Message);
                        }
                        break;

                    case "B":
                        try
                        {
                            _treeservices.Data(ref dataTree);
                            Console.WriteLine($"Dados: {dataTree}");
                            Console.WriteLine("\nSucesso!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "C":
                        try
                        {
                            _treeservices.Data(ref dataTree);
                            FileSaveServices.SaveTxt(dataTree);
                            Console.WriteLine(@"Sucesso! Salvo na pasta: C:\Arquivos Arvore Binaria\");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "D":
                        try
                        {
                            _treeservices.Data(ref dataTree);
                            Console.WriteLine($"Qual dos inteiros a seguir você quer deletar?");
                            Console.Write($" [{dataTree}] -> ");
                            int x = int.Parse(Console.ReadLine());
                            _treeservices.Delete(x);
                            Console.WriteLine("\nSucesso!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "E":
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção não identificada.");
                        break;
                }
                Console.Write("Prema uma tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
    }
}