using Y2023.Day6;

namespace Y2023.Tests;

public class day6Tests
{
    private readonly List<string> _raceInformation = new List<string>
    {
        "Time:      7  15   30",
        "Distance:  9  40  200",
    };
    [Fact]
    public void CountWaysToWin_ShouldReturnExpected()
    {
        BoatRaceCalculator.CountWaysToWin(_raceInformation).Should().Be(288);
    }
    [Fact]
    public void CountWaysToWinImproved_ShouldReturnExpected()
    {
        BoatRaceCalculator.CountWaysToWinImproved(_raceInformation).Should().Be(71503);
    }
    
}