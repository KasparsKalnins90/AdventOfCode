using System.Text.RegularExpressions;
using Y2023.Input;

namespace Y2023.Day6;

internal static class BoatRaceCalculator
{
    private static Regex _digitsRegex = new Regex(InputConstants.OneOrMoreDigitsRegex);

    public static long CountWaysToWin(List<string> raceInfo)
    {
        var raceInfos = GetRaceInfos(raceInfo);

        var amountsOfWaysToWin = raceInfos.Select(GetAmountOfWaysToWin).ToList();

        return amountsOfWaysToWin.Aggregate(1L, ((a, b) => a * b));
    }

    public static long CountWaysToWinImproved(List<string> raceInfo)
    {
        var raceInformation = GetRaceInfosImproved(raceInfo);


        return GetAmountOfWaysToWin(raceInformation);
    }

    private static long GetAmountOfWaysToWin(BoatRaceInformation raceInformation)
    {
        var waysToWin = 0L;
        var durationOfButtonPush = 0L;
        while (true)
        {
            var speed = 0L;
            durationOfButtonPush++;
            var timeLeftForTravel = raceInformation.RaceDuration - durationOfButtonPush;
            speed = durationOfButtonPush;
            var distanceTravelled = speed * timeLeftForTravel;
            if (durationOfButtonPush == raceInformation.RaceDuration)
            {
                return waysToWin;
            }

            if (distanceTravelled > raceInformation.CurrentRecord)
            {
                waysToWin++;
            }
        }
    }

    private static List<BoatRaceInformation> GetRaceInfos(List<string> raceInfo)
    {
        var raceInfos = new List<BoatRaceInformation>();
        var inputAsNumbers = raceInfo.Select(line =>
            _digitsRegex.Matches(line).Select(match => int.Parse(match.Value)).ToList()).ToList();
        for (var i = 0; i < inputAsNumbers[0].Count; i++)
        {
            raceInfos.Add(new BoatRaceInformation
            {
                RaceDuration = inputAsNumbers[0][i],
                CurrentRecord = inputAsNumbers[1][i]
            });
        }

        return raceInfos;
    }

    private static BoatRaceInformation GetRaceInfosImproved(List<string> raceInfo)
    {
        var raceInfos = new List<BoatRaceInformation>();
        var inputAsNumbers = raceInfo.Select(line =>
                _digitsRegex.Matches(line).Select(match => match.Value).ToList()).ToList()
            .Select(line => long.Parse(string.Join(string.Empty, line))).ToList();


        return new BoatRaceInformation
        {
            RaceDuration = inputAsNumbers[0],
            CurrentRecord = inputAsNumbers[1]
        };
    }
}