namespace Y2023.Day4;

internal static class TicketScoreChecker
{
    public static int GetTicketScore(List<string> tickets)
    {

        return ParseTickets(tickets)
            .Select(card => card.MyNumbers
                .Count(myNumber => card.WinningNumbers
                    .Any(winningNumber => winningNumber == myNumber)))
            .Where(matchCount => matchCount >= 1)
            .Sum(CaluclateCardScore);
    }

    public static int AccumulateScratchCards(List<string> scratchcards)
    {
        var tickets = ParseTickets(scratchcards).OrderBy(ticket => ticket.Id).ToList();
        foreach (var currentTicket in tickets)
        {
            var ticket = currentTicket;
            var pairs = currentTicket.MyNumbers
                .Count(myNumber => ticket.WinningNumbers.Any(winningNumber => winningNumber == myNumber));
            for (var i = 0; i < pairs; i++)
            {
                var ticketToUpdate = tickets.First(ticketInStack => ticketInStack.Id == currentTicket.Id + i + 1);
                ticketToUpdate.Count += currentTicket.Count;
            }
        }
        return tickets.Sum(ticket => ticket.Count);
    }
    private static List<ScratchTicket> ParseTickets(IEnumerable<string> ticketInfo)
    {
        return ticketInfo.Select(ticketLine =>
        {
            var splitLine = ticketLine.Split(':')[1].Split('|');

            var id = int.Parse(ticketLine.Split(':')[0].Split("Card ")[1]);
            var winningNumbers = splitLine[0]
            .Split(' ')
            .Where(num => !string.IsNullOrEmpty(num))
            .Select(int.Parse)
            .ToList();
            var myNumbers = splitLine[1]
            .Split(' ')
            .Where(num => !string.IsNullOrEmpty(num))
            .Select(int.Parse)
            .ToList();
            return new ScratchTicket
            {
                MyNumbers = myNumbers,
                WinningNumbers = winningNumbers,
                Id = id
            };
        })
            .ToList();
    }
    private static int CaluclateCardScore(int numberOfMatces)
    {
        var score = 1;
        for (var i = 1; i < numberOfMatces; i++)
        {
            score *= 2;
        }
        return score;
    }
}
