using castledice_game_data_logic.Content;
using castledice_game_data_logic.Extensions;
using castledice_game_logic;

namespace castledice_game_data_logic;

[Serializable]
public sealed class GameStartData
{
    public int BoardLength { get; }
    public int BoardWidth { get; }
    public CellType CellType { get; }
    public bool[,] CellsPresence { get; }
    public List<ContentData> GeneratedContent { get; }
    public int KnightHealth { get; }
    public int KnightPlaceCost { get; }
    /// <summary>
    /// This field represents ids of participants and also their turns order.
    /// </summary>
    public List<int> PlayersIds { get; }
    public List<PlayerDeckData> Decks { get; }

    public GameStartData(int boardLength, int boardWidth, CellType cellType, bool[,] cellsPresence, List<ContentData> generatedContent, int knightHealth, int knightPlaceCost, List<int> playersIds, List<PlayerDeckData> decks)
    {
        BoardLength = boardLength;
        BoardWidth = boardWidth;
        CellType = cellType;
        CellsPresence = cellsPresence;
        GeneratedContent = generatedContent;
        KnightHealth = knightHealth;
        KnightPlaceCost = knightPlaceCost;
        PlayersIds = playersIds;
        Decks = decks;
    }

    protected bool Equals(GameStartData other)
    {
        return BoardLength == other.BoardLength && 
               BoardWidth == other.BoardWidth && 
               CellType == other.CellType && 
               CellsPresence.Equals2D(other.CellsPresence) && 
               GeneratedContent.SequenceEqual(other.GeneratedContent) && 
               KnightHealth == other.KnightHealth && 
               KnightPlaceCost == other.KnightPlaceCost && 
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
        hashCode.Add(BoardLength);
        hashCode.Add(BoardWidth);
        hashCode.Add((int)CellType);
        hashCode.Add(CellsPresence);
        hashCode.Add(GeneratedContent);
        hashCode.Add(KnightHealth);
        hashCode.Add(KnightPlaceCost);
        hashCode.Add(PlayersIds);
        hashCode.Add(Decks);
        return hashCode.ToHashCode();
    }
}