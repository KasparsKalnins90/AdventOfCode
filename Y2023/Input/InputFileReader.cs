namespace Y2023.Input;

    internal class InputFileReader
{
    public string InputFileName { get; set; }
    public string ItemSeparator { get; set; } = "\r\n\r\n";

    public InputFileReader(string inputFileName)
    {
        InputFileName = inputFileName;
    }
    public InputFileReader(string inputFileName, string itemSeparator)
    {
        InputFileName = inputFileName;
        ItemSeparator = itemSeparator;
    }

    public List<string> GetItems()
    {
        return File
            .ReadAllText(
                $"{Directory.GetCurrentDirectory()}\\InputFiles\\{InputFileName}")
            .Split(ItemSeparator)
            .ToList();
    }
    public string GetText()
    {
        return File
            .ReadAllText(
                $"{Directory.GetCurrentDirectory()}\\InputFiles\\{InputFileName}");
    }

}
