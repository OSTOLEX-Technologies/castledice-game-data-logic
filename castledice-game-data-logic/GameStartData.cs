using castledice_game_data_logic.Content;
using castledice_game_data_logic.Content.Generated;
using castledice_game_data_logic.Content.Placeable;
using castledice_game_data_logic.Extensions;
using castledice_game_logic;

namespace castledice_game_data_logic;

[Serializable]
public sealed class GameStartData
{
    public string Version { get; }
    public int BoardLength { get; }
    public int BoardWidth { get; }
    public CellType CellType { get; }
    public bool[,] CellsPresence { get; }
    public List<GeneratedContentData> GeneratedContent { get; }
    public PlaceablesConfigData PlaceablesConfig { get; }
    
    /// <summary>
    /// This field represents ids of participants and also their turns order.
    /// </summary>
    public List<int> PlayersIds { get; }
    public List<PlayerDeckData> Decks { get; }

    public GameStartData(string version,
        int boardLength, 
        int boardWidth, 
        CellType cellType, 
        bool[,] cellsPresence, 
        List<GeneratedContentData> generatedContent,
        PlaceablesConfigData placeablesConfig,
        List<int> playersIds, 
        List<PlayerDeckData> decks)
    {
        Version = version;
        BoardLength = boardLength;
        BoardWidth = boardWidth;
        CellType = cellType;
        CellsPresence = cellsPresence;
        GeneratedContent = generatedContent;
        PlaceablesConfig = placeablesConfig;
        PlayersIds = playersIds;
        Decks = decks;
    }

    private bool Equals(GameStartData other)
    {
        return Version == other.Version && 
               BoardLength == other.BoardLength && 
               BoardWidth == other.BoardWidth && 
               CellType == other.CellType && 
               CellsPresence.Equals2D(other.CellsPresence) && 
               GeneratedContent.SequenceEqual(other.GeneratedContent) && 
               PlaceablesConfig.Equals(other.PlaceablesConfig) &&
               PlayersIds.SequenceEqual(other.PlayersIds) && 
               Decks.SequenceEqual(other.Decks);
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
        hashCode.Add(BoardLength);
        hashCode.Add(BoardWidth);
        hashCode.Add((int)CellType);
        hashCode.Add(CellsPresence);
        hashCode.Add(GeneratedContent);
        hashCode.Add(PlaceablesConfig);
        hashCode.Add(PlayersIds);
        hashCode.Add(Decks);
        return hashCode.ToHashCode();
    }
}