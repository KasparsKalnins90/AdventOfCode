using System.Security.AccessControl;

namespace Y2023.Day7;

internal static class PokerScoreCounter
{
    internal static long GetScoreWithJokers(List<string> pokerHandsAsStrings)
    {
        var hands = pokerHandsAsStrings.Select(hand =>
            new PokerHand(hand, true));

        
        return 0L;
    }
    internal static long GetScore(List<string> pokerHandsAsStrings)
    {
        var sortedHands = pokerHandsAsStrings.Select(hand =>
                new PokerHand(hand, false))
            .OrderBy(hand => hand.HandType)
            .ThenBy(hand => hand)
            .ToList();


        var result = 0L;
        for (int i = 0; i < sortedHands.Count(); i++)
        {
            result += sortedHands[i].Bet * (i + 1);
        }

        return result;
    }
}

internal static class PokerHandExtensions
{
    public static PokerHand ImproveHand(this PokerHand pokerHand)
    {
        var amountOfJokers = pokerHand.Cards.Count(card => card.CardSymbol == 'J');
        if (amountOfJokers == 0)
        {
            return pokerHand;
        }
        
        return pokerHand;
    }
}
internal class PokerCard
{
    public char CardSymbol { get; set; }
    public int Value { get; set; }

    public PokerCard(char cardSymbol, bool hasJoker)
    {
        CardSymbol = cardSymbol;
        Value = cardSymbol switch
        {
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            'T' => 10,
            'J' => hasJoker ? 1 : 11,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => throw new ArgumentOutOfRangeException(nameof(cardSymbol), cardSymbol, null)
        };
    }
}