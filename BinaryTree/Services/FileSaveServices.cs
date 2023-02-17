namespace BinaryTree.Services
{
    public static class FileSaveServices
    {
        public static void SaveTxt(string data)
        {
            string directoryPath = @"c:\Arquivos Arvore Binaria\";
            string txtPath = directoryPath + "ExportData.txt";
            Directory.CreateDirectory(directoryPath); //Cria o diretório descrito caso não exista.
            File.Delete(txtPath); //Deleta saves antigos caso exista.

            using (StreamWriter stream = File.AppendText(txtPath)) //Abre fluxo para writeline.
            {
                stream.WriteLine(data); //Escreve toda a string que veio no parâmetro.
            }
        }
    }
}