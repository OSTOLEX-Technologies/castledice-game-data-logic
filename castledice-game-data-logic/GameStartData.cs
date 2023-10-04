﻿using castledice_game_data_logic.Content;
using castledice_game_logic;

namespace castledice_game_data_logic;

[Serializable]
public class GameStartData
{
    public CellType CellType { get; set; }
    public bool[,] CellsPresence { get; set; }
    public List<ContentData> GeneratedContent { get; } = new();
    public int KnightHealth { get; set; }
    public int KnightPlaceCost { get; set; }
    public List<PlayerDeckData> Decks { get; } = new();
}