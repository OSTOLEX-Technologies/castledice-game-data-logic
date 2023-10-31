namespace castledice_game_data_logic;

[Serializable]
public sealed class GameData
{
    public int Id { get; }
    public string Config { get; }
    public DateTime GameStartedTime { get; }
    public DateTime GameEndedTime { get; set; }
    public int WinnerId { get; set; }
    public List<int> Players { get; }
    public string? History { get; set; }

    public GameData(int id, string config, DateTime gameStartedTime, List<int> players)
    {
        Id = id;
        Config = config;
        GameStartedTime = gameStartedTime;
        Players = players;
    }

    private bool Equals(GameData other)
    {
        return Id == other.Id && 
               Config == other.Config && 
               GameStartedTime.Equals(other.GameStartedTime) && 
               GameEndedTime.Equals(other.GameEndedTime) && 
               WinnerId == other.WinnerId && 
               Players.SequenceEqual(other.Players) && 
               History == other.History;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is GameData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Config, GameStartedTime, Players);
    }
}