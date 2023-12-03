using Y2023.Day1;
using Y2023.Day2;
using Y2023.Input;
var fileReader = new InputFileReader("Day2.txt", "\r\n");
var gameInfos = fileReader.GetItems();
//Console.WriteLine(CalibrationDocumentReader.SumCoordinates(coordinateList));
Console.WriteLine(CubeGameValidator.Validate(gameInfos));

