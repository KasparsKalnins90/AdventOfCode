using System.Numerics;

namespace Y2023.Day1;

internal static class CalibrationDocumentReader
{
    public static int GetCoordinates(string encodedMessage)
    {
        var firstNumber = encodedMessage.First(character => Char.IsDigit(character));
        var lastNumber = encodedMessage.Last(character => Char.IsDigit(character));
        return int.Parse($"{firstNumber}{lastNumber}");
    }
    public static int SumCoordinates(List<string> encodedMessages)
    {
        return encodedMessages.Sum(GetCoordinates);
    }
}
