using System.Text;

namespace Y2023.Day3;

internal class EngineTools
{

    private static readonly List<MappedChar> _map = new List<MappedChar>();

    public static int GetGearRatio(List<string> engineInfo)
    {
        MapEngineInfo(engineInfo);

        var serialNumberParts = GetSerialNumberParts();

        var serialNumbersNextToGears = serialNumberParts
            .Where(serialNumerPart =>
            serialNumerPart.Neighbors.Any(neigbor => neigbor.Value == '*')).ToList();

        var pairs = new List<List<SerialNumberPart>>();
        foreach (var serial in serialNumbersNextToGears)
        {
            var gearCoordinates = serial.Neighbors.First(n => n.Value == '*');
            var onesWithSharedGears = serialNumbersNextToGears
                .Where(serialNumberPart =>
                serialNumberPart.Neighbors
                .Any(neighbor =>
                neighbor.X == gearCoordinates.X
                && neighbor.Y == gearCoordinates.Y))
                .ToList();

            if (onesWithSharedGears.Count() == 2)
            {
                bool pairAlreadyAdded = pairs
                    .Any(pair =>
                    pair[0].Numbers == onesWithSharedGears[0].Numbers
                    && pair[1].Numbers == onesWithSharedGears[1].Numbers);

                if (!pairAlreadyAdded)
                {
                    pairs.Add(onesWithSharedGears);
                }
            }
        }
        var result = 0;
        foreach (var pair in pairs)
        {
            result += pair[0].Numbers * pair[1].Numbers;
        }

        return result;
    }

    private static List<SerialNumberPart> GetSerialNumberParts()
    {
        var serialNumberParts = new List<SerialNumberPart>();

        for (int i = 0; i < _map.Count; i++)
        {
            var serialNumberPart = new List<MappedChar>();
            while (char.IsDigit(_map[i].Value))
            {
                serialNumberPart.Add(_map[i]);
                i++;
            }
            if (serialNumberPart.Count > 0)
            {

                var leftCoordinate = serialNumberPart.Min(serialNumberPart => serialNumberPart.X);
                var rightCoordinate = serialNumberPart.Max(serialNumberPart => serialNumberPart.X);
                var serialNumberPartY = serialNumberPart[0].Y;

                var neighbors = GetNeigbors(leftCoordinate, rightCoordinate, serialNumberPartY);
                var serialNumber = GetNumberFromCoordinates(leftCoordinate, rightCoordinate, serialNumberPartY);

                serialNumberParts.Add(new SerialNumberPart() { Neighbors = neighbors, Numbers = serialNumber });
                serialNumberPart = new List<MappedChar>();
            }
        }
        return serialNumberParts;
    }

    public static int GetSerialNumberSum(List<string> engineInfo)
    {
        MapEngineInfo(engineInfo);


        return GetSerialNumberParts()
            .Where(serialNumberPart =>
            serialNumberPart.Neighbors.Any(neighbor => neighbor.Value != '.'))
            .Sum(snp => snp.Numbers);
    }

    public static List<MappedChar> GetNeigbors(int fromX, int toX, int y)
    {
        // above => ((mi.X >= fromX -1 && mi.X <= toX + 1) && mi.Y == y - 1)
        // below => ((mi.X >= fromX -1 && mi.X <= toX + 1) && mi.Y == y + 1)
        // to the left (mi.X == fromX-1 && mi.Y == y)
        // to the right => (mi.X == toX+ 1 && mi.Y == y)
        return _map
            .Where(mi =>
             ((mi.X >= fromX - 1 && mi.X <= toX + 1) && mi.Y == y - 1)
             || ((mi.X >= fromX - 1 && mi.X <= toX + 1) && mi.Y == y + 1)
             || (mi.X == fromX - 1 && mi.Y == y)
             || (mi.X == toX + 1 && mi.Y == y))
            .ToList();
    }
    private static int GetNumberFromCoordinates(int fromX, int toX, int y)
    {
        var number = new StringBuilder();
        for (int i = fromX; i < toX + 1; i++)
        {
            number.Append(_map.First(mappedChar => mappedChar.X == i && mappedChar.Y == y).Value.ToString());
        }
        return int.Parse(number.ToString());
    }

    private static void MapEngineInfo(List<string> input)
    {
        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                _map.Add(new MappedChar()
                {
                    X = x,
                    Y = y,
                    Value = input[y][x]
                });
            }
        }
    }
}
