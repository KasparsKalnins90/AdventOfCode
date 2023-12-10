using Y2023.Day7;

namespace Y2023.Tests;

public class Day7Tests
{
    private readonly List<string> _pokerHands = new List<string>()
    {
        "32T3K 765",
        "T55J5 684",
        "KK677 28",
        "KTJJT 220",
        "QQQJA 483",
    };

    [Fact]
    public void GetPokerScore_ShouldReturnExpectedScore()
    {
        PokerScoreCounter.GetScore(_pokerHands).Should().Be(6440);
    }
}