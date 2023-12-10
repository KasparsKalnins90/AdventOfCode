using Y2023.Day8;

namespace Y2023.Tests;

public class Day8Tests
{
    private readonly List<string> _input = new List<string>
    {
        "LLR",
        "",
        "AAA = (BBB, BBB)",
        "BBB = (AAA, ZZZ)",
        "ZZZ = (ZZZ, ZZZ)",
    };
    
    [Fact]
    public void NavigateDesert_ShouldReturnExpected()
    {
        DesertNavigator.Navigate(_input).Should().Be(6);
    }

    [Fact]
    public void NavigateBetter_ShouldReturnExpected()
    {
        var betterInput = new List<string>()
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)",
        };
        DesertNavigator.NavigateBetter(betterInput).Should().Be(6);
    }
}