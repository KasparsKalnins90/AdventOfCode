using System.Net.Sockets;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Y2023.Day5;

internal static class SeedInfoExtractor
{
    private static Regex _numbersRegex = new("(\\d+)");

    public static long FindLowestGround(List<string> seedInfo)
    {
        var seeds =
            _numbersRegex
                .Matches(seedInfo[0])
                .Select(match => long.Parse(match.Value)).ToList();
        var seedMapInfoLists = GetSeedMapInfos(seedInfo.Where(line => !string.IsNullOrEmpty(line)));
        var lowestPoints = new List<long>();

        foreach (var seed in seeds)
        {
            var lowestPoint = seed;
            foreach (var seedMapInfoList in seedMapInfoLists)
            {
                lowestPoint = CheckSeedMaps(seedMapInfoList, lowestPoint);
            }

            lowestPoints.Add(lowestPoint);
        }

        return lowestPoints.Min();
    }

    public static long FindLowestGroundImproved(List<string> seedInfo)
    {
        var seeds =
            _numbersRegex
                .Matches(seedInfo[0])
                .Select(match => long.Parse(match.Value)).ToList();
        var seedMapInfoLists = GetSeedMapInfos(seedInfo.Where(line => !string.IsNullOrEmpty(line)));
        var lowestPoints = new List<long>();
        var seedRanges = new List<SeedRange>();

        for (int i = 0; i < seeds.Count; i += 2)
        {
            var rangeStart = seeds[i];
            var rangeLength = seeds[i + 1];
            seedRanges.Add(new SeedRange()
            {
                RangeStart = rangeStart,
                RangeEnd = rangeStart + rangeLength,
            });
        }

        var remapped = new List<SeedRange>();
        foreach (var seedRange in seedRanges)
        {
            var seedRangesToProcess = new List<SeedRange>{seedRange};
            foreach (var seedMapInfoList in seedMapInfoLists)
            {  
                //seedRangess.Add(RemapSeedRange(seedRange, seedMapInfoList));
            }
            remapped.AddRange(seedRanges);
        }

        return remapped.Min(x => x.RangeStart);
    }

    public static List<SeedRange> RemapSeedRange(SeedRange seedRange, List<SeedMappingInfo> seedMapInfos)
    {
        var newRanges = new List<SeedRange?>();
        foreach (var seedMapInfo in seedMapInfos)
        {
            newRanges.Add(GetLeftSeedRange(seedRange, seedMapInfo));
            newRanges.Add(GetRightSeedRange(seedRange, seedMapInfo));
            newRanges.Add(GetMiddleSeedRange(seedRange, seedMapInfo));
        }

        return newRanges.Where(range => range is not null).ToList()!;
    }

    private static SeedRange? GetMiddleSeedRange(SeedRange seedRange, SeedMappingInfo seedMappingInfo)
    {
        var offset = seedMappingInfo.SourceRangeStart - seedMappingInfo.DestinationRangeStart;
        if (seedRange.RangeStart > seedMappingInfo.SourceRangeStart)
        {
            if (seedRange.RangeEnd > seedMappingInfo.SourceRangeEnd)
            {
                return null;
            }

            if (seedRange.RangeEnd < seedMappingInfo.SourceRangeEnd)
            {
                return new SeedRange()
                {
                    RangeStart = seedRange.RangeStart + offset,
                    RangeEnd = seedRange.RangeEnd + offset,
                };
            }
        }

        if (seedRange.RangeStart < seedMappingInfo.SourceRangeStart)
        {
            if (seedRange.RangeEnd < seedMappingInfo.SourceRangeEnd)
            {
                return new SeedRange()
                {
                    RangeStart = seedMappingInfo.DestinationRangeStart,
                    RangeEnd = seedRange.RangeEnd + offset
                };
            }

            if (seedRange.RangeEnd > seedMappingInfo.SourceRangeEnd)
            {
                return new SeedRange()
                {
                    RangeStart = seedMappingInfo.DestinationRangeStart,
                    RangeEnd = seedMappingInfo.DestinationRangeEnd
                };
            }
        }

        return null;
    }

    private static SeedRange? GetRightSeedRange(SeedRange seedRange, SeedMappingInfo seedMappingInfo)
    {
        if (seedRange.RangeEnd < seedMappingInfo.SourceRangeEnd)
        {
            return null;
        }

        return new SeedRange()
        {
            RangeStart = seedMappingInfo.SourceRangeEnd,
            RangeEnd = seedRange.RangeEnd
        };
    }

    private static SeedRange? GetLeftSeedRange(SeedRange seedRange, SeedMappingInfo seedMappingInfo)
    {
        if (seedRange.RangeEnd < seedMappingInfo.SourceRangeStart)
        {
            return null;
        }

        return new SeedRange()
        {
            RangeStart = seedRange.RangeStart,
            RangeEnd = seedMappingInfo.SourceRangeStart
        };
    }

    private static long CheckSeedMaps(List<SeedMappingInfo> seedMapInfos, long valueToCheck)
    {
        foreach (var seedMap in seedMapInfos)
        {
            var sourceRangeEnd = seedMap.SourceRangeStart + seedMap.RangeLength;
            if (valueToCheck >= seedMap.SourceRangeStart &&
                valueToCheck <= sourceRangeEnd)
            {
                var offset = valueToCheck - seedMap.SourceRangeStart;
                return seedMap.DestinationRangeStart + offset;
            }
        }

        return valueToCheck;
    }

    private static List<List<SeedMappingInfo>> GetSeedMapInfos(IEnumerable<string> seedInfo)
    {
        var seedMapInfos = new List<List<SeedMappingInfo>>();

        var currentList = new List<SeedMappingInfo>();
        foreach (var line in seedInfo)
        {
            var numbers = _numbersRegex.Matches(line).Select(number => long.Parse(number.Value)).ToList();
            if (line.StartsWith("seeds"))
            {
                continue;
            }

            if (numbers.Count == 0)
            {
                if (currentList.Count != 0)
                {
                    seedMapInfos.Add(currentList);
                }

                currentList = new List<SeedMappingInfo>();
            }
            else
            {
                currentList.Add(
                    new SeedMappingInfo(
                        numbers[0],
                        numbers[1],
                        numbers[2]
                    ));
            }
        }

        seedMapInfos.Add(currentList);
        return seedMapInfos;
    }
}

internal class SeedMappingInfo
{
    public long DestinationRangeStart { get; set; }
    public long SourceRangeStart { get; set; }
    public long RangeLength { get; set; }
    public long SourceRangeEnd { get; set; }
    public long DestinationRangeEnd { get; set; }

    public SeedMappingInfo(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        DestinationRangeStart = destinationRangeStart;
        SourceRangeStart = sourceRangeStart;
        RangeLength = rangeLength;
        SourceRangeEnd = sourceRangeStart + rangeLength;
        DestinationRangeEnd = destinationRangeStart + rangeLength;
    }
}

public class SeedRange
{
    public long RangeStart { get; set; }
    public long RangeEnd { get; set; }
}