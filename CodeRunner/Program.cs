using Y2023.Day7;
using Y2023.Input;
var fileReader = new InputFileReader("Day7.txt", "\r\n");
var pokerHandInfo = fileReader.GetItems();
Console.WriteLine(PokerScoreCounter.GetScore(pokerHandInfo));


