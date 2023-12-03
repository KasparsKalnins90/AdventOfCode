namespace Y2023.Day2;

internal static class CubeGameValidator
{
    public static int Validate(List<string> cubeGames)
    {
        var games = cubeGames.Select(game => new CubeGame(game)).ToList();
        var result = games.Where(game => 
        game.cubeInfo["red"] <= 12 
        && game.cubeInfo["green"] <= 13
        && game.cubeInfo["blue"] <= 14)
            .Select(game => game.Id)
            .Sum();
        return result;
    }

    public static int GetSumPower(List<string> cubeGames)
    {
        var games = cubeGames.Select(game => new CubeGame(game)).ToList();
        var total = 0;
        var minNeededCubesInGames = games.Select(game => game.cubeInfo.Select(x => x.Value));
        foreach (var cubes in minNeededCubesInGames)
        {
            var multiplicationResult = 1;
            foreach (var item in cubes)
            {
                multiplicationResult *= item;
            }
            total += multiplicationResult;
        }
        return total;
    }
}
