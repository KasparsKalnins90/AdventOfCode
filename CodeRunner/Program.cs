using Y2023.Day4;
using Y2023.Day6;
using Y2023.Input;
var fileReader = new InputFileReader("Day6.txt", "\r\n");
var raceInfos = fileReader.GetItems();
Console.WriteLine(BoatRaceCalculator.CountWaysToWinImproved(raceInfos));


