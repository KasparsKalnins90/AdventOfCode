using Y2023.Day5;

namespace Y2023.Tests;

public class Day5Tests
{
    private readonly List<string> _seedInfo = new()
    {
        "seeds: 79 14 55 13",
        "",
        "seed-to-soil map:",
        "50 98 2",
        "52 50 48",
        "",
        "soil-to-fertilizer map:",
        "0 15 37",
        "37 52 2",
        "39 0 15",
        "",
        "fertilizer-to-water map:",
        "49 53 8",
        "0 11 42",
        "42 0 7",
        "57 7 4",
        "",
        "water-to-light map:",
        "88 18 7",
        "18 25 70",
        "",
        "light-to-temperature map:",
        "45 77 23",
        "81 45 19",
        "68 64 13",
        "",
        "temperature-to-humidity map:",
        "0 69 1",
        "1 0 69",
        "",
        "humidity-to-location map:",
        "60 56 37",
        "56 93 4",
    };

    [Fact]
    public void FindLowestGround_ShouldReturnExpected()
    {
        SeedInfoExtractor.FindLowestGround(_seedInfo).Should().Be(35u);
    }

    [Fact]
    public void FindLowestGroundImproved_ShouldReturnExpected()
    {
        SeedInfoExtractor.FindLowestGroundImproved(_seedInfo).Should().Be(46);
    }

    [Fact]
    public void RemapRanges()
    {
        var seedMapInfos = new List<SeedMappingInfo>
        {
            new SeedMappingInfo(10, 5, 5),
        };
        var seedRange = new SeedRange()
        {
            RangeStart = 1L,
            RangeEnd = 35L,
        };

        var expectedResult = new List<SeedRange>()
        {
            new()
            {
                RangeStart = 1,
                RangeEnd = 5,
            },
            new ()
            {
                RangeStart = 10,
                RangeEnd = 15
            },
            new ()
            {
                RangeStart = 10,
                RangeEnd = 35
            },
        };
        
        SeedInfoExtractor.RemapSeedRange(seedRange, seedMapInfos).Should().BeEquivalentTo(expectedResult);
    }
}