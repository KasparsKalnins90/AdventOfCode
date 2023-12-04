using FluentAssertions;
using Y2023.Day3;
namespace Y2023.Tests;

public class Day3Tests
{
    [Fact]
    public void GetSerialNumber_ShouldReturnExpected()
    {
        var input = new List<string>{
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        };

        EngineTools.GetSerialNumber(input).Should().Be(4361);
    }
}
