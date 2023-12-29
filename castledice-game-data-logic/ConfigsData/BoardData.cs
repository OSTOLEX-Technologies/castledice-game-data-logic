﻿using castledice_game_data_logic.Content;
using castledice_game_data_logic.Extensions;
using castledice_game_logic;

namespace castledice_game_data_logic.ConfigsData;

public sealed class BoardData
{
    public int BoardLength { get; }
    public int BoardWidth { get; }
    public CellType CellType { get; }
    public bool[,] CellsPresence { get; }
    public List<ContentData> GeneratedContent { get; }

    public BoardData(int boardLength, int boardWidth, CellType cellType, bool[,] cellsPresence, List<ContentData> generatedContent)
    {
        BoardLength = boardLength;
        BoardWidth = boardWidth;
        CellType = cellType;
        CellsPresence = cellsPresence;
        GeneratedContent = generatedContent;
    }

    private bool Equals(BoardData other)
    {
        return BoardLength == other.BoardLength &&
               BoardWidth == other.BoardWidth &&
               CellType == other.CellType &&
               CellsPresence.Equals2D(other.CellsPresence) &&
               GeneratedContent.SequenceEqual(other.GeneratedContent);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is BoardData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BoardLength, BoardWidth, (int)CellType, CellsPresence, GeneratedContent);
    }
}