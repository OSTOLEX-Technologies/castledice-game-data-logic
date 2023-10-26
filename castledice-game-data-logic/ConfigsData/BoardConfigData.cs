using castledice_game_data_logic.Content.Generated;
using castledice_game_data_logic.Extensions;
using castledice_game_logic;

namespace castledice_game_data_logic.Content.Placeable;

public sealed class BoardConfigData
{
    public int BoardLength { get; }
    public int BoardWidth { get; }
    public CellType CellType { get; }
    public bool[,] CellsPresence { get; }
    public List<GeneratedContentData> GeneratedContent { get; }

    public BoardConfigData(int boardLength, int boardWidth, CellType cellType, bool[,] cellsPresence, List<GeneratedContentData> generatedContent)
    {
        BoardLength = boardLength;
        BoardWidth = boardWidth;
        CellType = cellType;
        CellsPresence = cellsPresence;
        GeneratedContent = generatedContent;
    }

    private bool Equals(BoardConfigData other)
    {
        return BoardLength == other.BoardLength &&
               BoardWidth == other.BoardWidth &&
               CellType == other.CellType &&
               CellsPresence.Equals2D(other.CellsPresence) &&
               GeneratedContent.SequenceEqual(other.GeneratedContent);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is BoardConfigData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BoardLength, BoardWidth, (int)CellType, CellsPresence, GeneratedContent);
    }
}