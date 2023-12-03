namespace Y2023.Day2;

internal class CubeGame
{
    public int Id { get; set; }
    public Dictionary<string, int> cubeInfo{ get; set; }
    public CubeGame(string gameInfo)
    {
        cubeInfo = new Dictionary<string, int>();
        var SplitGameAndId = gameInfo.Split(':');
        Id = int.Parse(SplitGameAndId[0].Split(' ')[1]);
        var games = SplitGameAndId[1].Replace(';', ',').Split(",");
        foreach(var game in games)
        {
            var amouuntAndColor = game.Trim().Split(' ');
            var color = amouuntAndColor[1];
            var amount = int.Parse(amouuntAndColor[0]);
            if (!cubeInfo.ContainsKey(color))
            {
                cubeInfo.Add(color, amount);
            } else if (cubeInfo[color] < amount)
            {
                cubeInfo[color] = amount;
            }
        }
    }
}
