using Y2023.Day4;
using Y2023.Input;
var fileReader = new InputFileReader("Day4.txt", "\r\n");
var tickets = fileReader.GetItems();
Console.WriteLine(TicketScoreChecker.AccumulateScratchCards(tickets));


