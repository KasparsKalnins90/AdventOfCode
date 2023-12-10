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
}