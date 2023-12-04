using FluentAssertions;
using Y2023.Day3;
namespace Y2023.Tests;

public class Day3Tests
{
    private readonly List<string> _testData = new List<string>{
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

    [Fact]
    public void GetSerialNumber_ShouldReturnExpected()
    {

        EngineTools.GetSerialNumberSum(_testData).Should().Be(4361);
    }

    [Fact]
    public void GetGearRatio_ShouldReturnExpected()
    {
        EngineTools.GetGearRatio(_testData).Should().Be(467835);
    }
}
