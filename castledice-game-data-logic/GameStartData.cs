﻿using castledice_game_data_logic.ConfigsData;
using castledice_game_data_logic.Content;
using castledice_game_data_logic.Extensions;
using castledice_game_logic;

namespace castledice_game_data_logic;

[Serializable]
public sealed class GameStartData
{
    public string Version { get; }
    public BoardData BoardData { get; }

    public PlaceablesConfigData PlaceablesConfigData { get; }
    
    /// <summary>
    /// This field represents ids of participants and also their turns order.
    /// </summary>
    public List<int> PlayersIds { get; }
    public List<PlayerDeckData> Decks { get; }

    public GameStartData(string version,
        BoardData boardData,
        PlaceablesConfigData placeablesConfigData,
        List<int> playersIds, 
        List<PlayerDeckData> decks)
    {
        Version = version;
        PlaceablesConfigData = placeablesConfigData;
        PlayersIds = playersIds;
        Decks = decks;
        BoardData = boardData;
    }

    private bool Equals(GameStartData other)
    {
        return Version == other.Version && 
               BoardData.Equals(other.BoardData)  && 
               PlaceablesConfigData.Equals(other.PlaceablesConfigData) &&
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
        hashCode.Add(PlaceablesConfigData);
        hashCode.Add(PlayersIds);
        hashCode.Add(Decks);
        return hashCode.ToHashCode();
    }
}