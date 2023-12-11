using System.Text.RegularExpressions;
using Y2023.Input;

namespace Y2023.Day8;

internal static class DesertNavigator
{
    private static readonly Regex _capitalLettersRegex = new Regex(InputConstants.OneOrMoreCapitalLettersRegex);

    private static readonly Regex _capitalLettersAndDigitsRegex = new Regex("([a-zA-Z0-9]+)");

    public static decimal NavigateBetter(List<string> navigationInstructions)
    {
        var directions = navigationInstructions[0];
        var nodes = new List<DesertNavigatorNode>();
        for (var i = 2; i < navigationInstructions.Count; i++)
        {
            var matches = _capitalLettersAndDigitsRegex.Matches(navigationInstructions[i]);
            nodes.Add(new DesertNavigatorNode
            {
                Key = matches[0].Value,
                Left = matches[1].Value,
                Right = matches[2].Value
            });
        }
        var startingNodes =
            nodes
                .Where(node => node.Key[2] == 'A').ToList();

        var movesNodesNeed = startingNodes
            .Select(node => GetMovesNeededBetter(nodes, node, directions))
            .ToList();
        for (long i = movesNodesNeed.Max();; i+=movesNodesNeed.Max())
        {
            if (i % 10000000== 0)
            {
                Console.WriteLine($"moves so far : {i}");
            }
            if (movesNodesNeed.All(node => i % node == 0))
            {
                return i;
            }
        }
    }
    
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
        return GetMovesNeeded(nodes, currentNode, directions);
    }

    private static int GetMovesNeeded(List<DesertNavigatorNode> allNodes, DesertNavigatorNode currentNode,
        string directions)
    {
        var moves = 0;
        while (true)
        {
            foreach (var direction in directions)
            {
                moves++;
                if (direction == 'L')
                {
                    currentNode = allNodes.First(node => node.Key == currentNode.Left);
                }

                if (direction == 'R')
                {
                    currentNode = allNodes.First(node => node.Key == currentNode.Right);
                }

                if (currentNode.Key == "ZZZ")
                {
                    return moves;
                }
            }
        }
    }

    private static int GetMovesNeededBetter(List<DesertNavigatorNode> allNodes, DesertNavigatorNode currentNode,
        string directions)
    {
        var moves = 0;
        while (true)
        {
            foreach (var direction in directions)
            {
                moves++;
                if (direction == 'L')
                {
                    currentNode = allNodes.First(node => node.Key == currentNode.Left);
                }

                if (direction == 'R')
                {
                    currentNode = allNodes.First(node => node.Key == currentNode.Right);
                }

                if (currentNode.Key[2] == 'Z')
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