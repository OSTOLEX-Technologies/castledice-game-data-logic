using castledice_game_data_logic.Content;
using castledice_game_logic;

namespace castledice_game_data_logic;

[Serializable]
public class GameStartData
{
    public int BoardLength { get; set; }
    public int BoardWidth { get; set; }
    public CellType CellType { get; set; }
    public bool[,] CellsPresence { get; set; }
    public List<ContentData> GeneratedContent { get; set; }
    public int KnightHealth { get; set; }
    public int KnightPlaceCost { get; set; }
    /// <summary>
    /// This field represents ids of participants and also their turns order.
    /// </summary>
    public List<int> PlayersIds { get; set; }
    public List<PlayerDeckData> Decks { get; set; }

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
}