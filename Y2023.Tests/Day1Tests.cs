
using FluentAssertions;
using FluentAssertions.Extensions;
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
}