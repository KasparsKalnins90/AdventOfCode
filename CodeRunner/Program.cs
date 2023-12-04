using Y2023.Day3;
using Y2023.Input;
var fileReader = new InputFileReader("Day3.txt", "\r\n");
var gameInfos = fileReader.GetItems();
Console.WriteLine(EngineTools.GetSerialNumber(gameInfos));


