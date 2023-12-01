using Y2023.Day1;
using Y2023.Input;
var fileReader = new InputFileReader("Day1.txt", "\r\n");
var coordinateList = fileReader.GetItems();
    Console.WriteLine(CalibrationDocumentReader.SumCoordinates(coordinateList));