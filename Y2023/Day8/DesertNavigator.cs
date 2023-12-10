using System.Text.RegularExpressions;
using Y2023.Input;

namespace Y2023.Day8;

internal static class DesertNavigator
{
    private static readonly Regex _capitalLettersRegex = new Regex(InputConstants.OneOrMoreCapitalLettersRegex);

    public static int Navigate(List<string> navigationInstructions)
    {
        var directions = navigationInstructions[0];
        var nodes = new List<DesertNavigatorNode>();
        for (int i = 2; i < navigationInstructions.Count; i++)
        {
            var matches = _capitalLettersRegex.Matches(navigationInstructions[i]);
            nodes.Add(new DesertNavigatorNode
            {
                Key = matches[0].Value,
                Left = matches[1].Value,
                Right = matches[2].Value
            });
        }

        var currentNode = nodes.First(node => node.Key == "AAA");
        var moves = 0;
        while (true)
        {
            foreach (var direction in directions)
            {
                moves++;
                if (direction == 'L')
                {
                    currentNode = nodes.First(node => node.Key == currentNode.Left);
                }
                if (direction == 'R')
                {
                    currentNode = nodes.First(node => node.Key == currentNode.Right);
                }

                if (currentNode.Key == "ZZZ")
                {
                    return moves;
                }
            }
        }
    }
}

internal class DesertNavigatorNode
{
    public string Key { get; set; }
    public string Left { get; set; }
    public string Right { get; set; }
}