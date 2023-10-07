using castledice_game_data_logic.Content;
using castledice_game_logic;

namespace castledice_game_data_logic;

[Serializable]
public class GameStartData
{
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

    public GameStartData(CellType cellType, bool[,] cellsPresence, List<ContentData> generatedContent, int knightHealth, int knightPlaceCost, List<int> playersIds, List<PlayerDeckData> decks)
    {
        CellType = cellType;
        CellsPresence = cellsPresence;
        GeneratedContent = generatedContent;
        KnightHealth = knightHealth;
        KnightPlaceCost = knightPlaceCost;
        PlayersIds = playersIds;
        Decks = decks;
    }
}