namespace Y2023.Day7;

internal class PokerHand : IComparable<PokerHand>
{
    public List<PokerCard> Cards { get; set; }
    public long Bet { get; set; }
    public HandType HandType { get; set; }

    public PokerHand(string pokerHandInfo, bool hasJoker)
    {
        Cards = new List<PokerCard>();
        var split = pokerHandInfo.Split(' ');
        for (int i = 0; i < split[0].Length; i++)
        {
            Cards.Add(new PokerCard(split[0][i], hasJoker));
        }

        HandType = GetHandType(Cards);
        Bet = long.Parse(split[1].Trim());
    }

    private HandType GetHandType(List<PokerCard> pokerCards)
    {
        var handSymbols = new Dictionary<char, int>();
        foreach (var card in pokerCards)
        {
            if (handSymbols.ContainsKey(card.CardSymbol))
            {
                handSymbols[card.CardSymbol]++;
            }
            else
            {
                handSymbols.Add(card.CardSymbol, 1);
            }
        }

        switch (handSymbols.Count)
        {
            case 5:
                return HandType.HighCard;
            case 1:
                return HandType.FiveOfAKind;
            default:
            {
                if (handSymbols.Any(x => x.Value == 4))
                {
                    return HandType.FourOfAKind;
                }

                if (handSymbols.Any(x => x.Value == 3) && handSymbols.Any(x => x.Value == 2))
                {
                    return HandType.FullHouse;
                }

                if (handSymbols.Any(x => x.Value == 3) && handSymbols.Count == 3)
                {
                    return HandType.ThreeOfAKind;
                }

                if (handSymbols.Count(x => x.Value == 2) == 2)
                {
                    return HandType.TwoPair;
                }

                if (handSymbols.Count == 4)
                {
                    return HandType.OnePair;
                }

                break;
            }
        }

        return HandType.HighCard;
    }

    public int CompareTo(PokerHand? y)
    {
        for (var i = 0; i < Cards.Count; i++)
        {
            var result = Cards[i].Value.CompareTo(y.Cards[i].Value);
            if (result != 0)
            {
                return result;
            }
        }
        return 0;
    }
}