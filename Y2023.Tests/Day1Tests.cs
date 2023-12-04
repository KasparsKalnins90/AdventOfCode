
using FluentAssertions;
using Y2023.Day1;

namespace Y2023.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("ab1scl3", 13)]
    [InlineData("ab1scl32", 12)]
    public void GetCoordinates_ShouldReturnExpected(string input, int expectedResult)
    {
        CalibrationDocumentReader.GetCoordinates(input)
            .Should()
            .Be(expectedResult);

    }

    [Fact]
    public void GetCoordinateSum_ReturnsExpected()
    {
        var input = new List<string>() {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"};

        CalibrationDocumentReader.SumCoordinates(input).Should().Be(142);
    }

    [Theory]
    [InlineData("onetwo", "12")]
    [InlineData("eightwothree", "8wo3")]

    public void TranslateWordsToNumbers_ShouldReturnExpected(string input, string expectedResult)
    {
        CalibrationDocumentReader.TranslateWordsToNumbers(input).Should().Be(expectedResult);
    }

    [Fact]
    public void GetCoordinateSumImproved_ReturnsExpected()
    {
        var input = new List<string>() {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",};

        CalibrationDocumentReader.SumCoordinatesImproved(input).Should().Be(281);
    }
}