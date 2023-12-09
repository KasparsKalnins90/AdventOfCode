using Y2023.Day5;
using Y2023.Input;
var fileReader = new InputFileReader("Day5.txt", "\r\n");
var seedInfos = fileReader.GetItems();
Console.WriteLine( SeedInfoExtractor.FindLowestGroundImproved(seedInfos));


