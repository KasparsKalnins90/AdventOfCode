using Y2023.Day8;
using Y2023.Input;
var fileReader = new InputFileReader("Day8.txt", "\r\n");
var navigationInformation = fileReader.GetItems();
Console.WriteLine(DesertNavigator.Navigate(navigationInformation));


