using System;
using System.IO.Pipes;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Y2023.Day1;

internal static class CalibrationDocumentReader
{
    private static readonly Regex _numbersAsWordsRegex = new Regex("(one|two|three|four|five|six|seven|eight|nine)");
    private static readonly Dictionary<string, string> _numbersAsWords = new Dictionary<string, string>() {
        { "one" , "1"},
        { "two" , "2"},
        { "three", "3" },
        { "four" , "4"},
        { "five", "5" },
        { "six", "6" },
        { "seven", "7"},
        { "eight", "8" },
        { "nine", "9" }
    };
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
    public static int SumCoordinatesImproved(List<string> encodedMessages)
    {
        var translatedMessages = encodedMessages.Select(TranslateWordsToNumbers).ToList();
        foreach (var tm in translatedMessages)
        {
            var smth = GetCoordinates(tm);
        }
        return translatedMessages.Sum(GetCoordinates);
    }
    public static string TranslateWordsToNumbers(string translatable)
    {
        for (int i = 1; i < translatable.Length+1; i++)
        {
            var currentSubstring = translatable.Substring(0, i);
            foreach (var pair in _numbersAsWords)
            {
                var newSubstring = currentSubstring.Replace(pair.Key, pair.Value);
                if(newSubstring.Length < currentSubstring.Length)
                {
                    translatable = translatable.Replace(currentSubstring, newSubstring);
                    i-=2;
                }
            }
        }

        return translatable;
    }
}
