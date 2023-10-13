using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic;

[Serializable]
public sealed class PlayerDeckData
{
    public int PlayerId { get; }
    public List<PlacementType> AvailablePlacements { get; }

    public PlayerDeckData(int playerId, List<PlacementType> availablePlacements)
    {
        PlayerId = playerId;
        AvailablePlacements = availablePlacements;
    }

    private bool Equals(PlayerDeckData other)
    {
        return PlayerId == other.PlayerId && AvailablePlacements.SequenceEqual(other.AvailablePlacements);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PlayerDeckData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PlayerId, AvailablePlacements);
    }
}