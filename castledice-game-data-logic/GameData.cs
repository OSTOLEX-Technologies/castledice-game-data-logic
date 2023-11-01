using Newtonsoft.Json;

namespace castledice_game_data_logic;

[Serializable]
public sealed class GameData
{
    [JsonProperty("id")]
    public int Id { get; }
    [JsonProperty("config")]
    public string Config { get; }
    [JsonProperty("game_started_time")]
    public DateTime GameStartedTime { get; }
    [JsonProperty("game_ended_time")]
    public DateTime GameEndedTime { get; set; }
    [JsonProperty("winner")]
    public int? WinnerId { get; set; } = null;
    [JsonProperty("users")]
    public List<int> Players { get; }
    [JsonProperty("history")]
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