using castledice_game_data_logic.ConfigsData;
using castledice_game_data_logic.Content;
using castledice_game_data_logic.Extensions;
using castledice_game_data_logic.TurnSwitchConditions;
using castledice_game_logic;

namespace castledice_game_data_logic;

[Serializable]
public sealed class GameStartData
{
    public string Version { get; }
    public BoardData BoardData { get; }
    public PlaceablesConfigData PlaceablesConfigData { get; }
    public TscConfigData TscConfigData { get; }
    /// <summary>
    /// Order of objects in this collection corresponds to players turns order.
    /// </summary>
    public List<PlayerData> PlayersData { get; }

    public GameStartData(string version,
        BoardData boardData,
        PlaceablesConfigData placeablesConfigData,
        TscConfigData tscConfigData,
        List<PlayerData> playersData)
    {
        Version = version;
        PlaceablesConfigData = placeablesConfigData;
        TscConfigData = tscConfigData;
        PlayersData = playersData;
        BoardData = boardData;
    }

    private bool Equals(GameStartData other)
    {
        return Version == other.Version && 
               BoardData.Equals(other.BoardData)  && 
               PlaceablesConfigData.Equals(other.PlaceablesConfigData) &&
               TscConfigData.Equals(other.TscConfigData) &&
               PlayersData.SequenceEqual(other.PlayersData);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GameStartData)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Version);
        hashCode.Add(BoardData);
        hashCode.Add(PlaceablesConfigData);
        hashCode.Add(TscConfigData);
        hashCode.Add(PlayersData);
        return hashCode.ToHashCode();
    }
}