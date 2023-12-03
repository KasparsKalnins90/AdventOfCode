namespace Y2023.Day2;

internal static class CubeGameValidator
{
    public static int Validate(List<string> cubeGames)
    {
        var games = cubeGames.Select(game => new CubeGame(game)).ToList();
        //12 red cubes, 13 green cubes, and 14 blue cubes
        var result = games.Where(game => 
        game.cubeInfo["red"] <= 12 
        && game.cubeInfo["green"] <= 13
        && game.cubeInfo["blue"] <= 14)
            .Select(game => game.Id)
            .Sum();
        return result;
    }
}
