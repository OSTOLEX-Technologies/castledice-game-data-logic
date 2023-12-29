using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic;

[Serializable]
public sealed class PlayerData
{
    public int PlayerId { get; }
    public List<PlacementType> AvailablePlacements { get; }
    public TimeSpan TimeSpan { get; }

    public PlayerData(int playerId, List<PlacementType> availablePlacements, TimeSpan timeSpan)
    {
        PlayerId = playerId;
        AvailablePlacements = availablePlacements;
        TimeSpan = timeSpan;
    }

    private bool Equals(PlayerData other)
    {
        return PlayerId == other.PlayerId && AvailablePlacements.SequenceEqual(other.AvailablePlacements) && TimeSpan.Equals(other.TimeSpan);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is PlayerData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PlayerId, AvailablePlacements, TimeSpan);
    }
}