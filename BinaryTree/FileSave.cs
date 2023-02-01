namespace BinaryTree
{
    public static class FileSave
    {
        public static void SaveTxt(string data)
        {
            string directoryPath = @"c:\Arquivos Arvore Binaria\";
            string txtPath = directoryPath + "ExportData.txt";
            Directory.CreateDirectory(directoryPath);
            File.Delete(txtPath);
            using (StreamWriter stream = File.AppendText(txtPath))
            {
                stream.WriteLine(data);
            }
        }
    }
}
