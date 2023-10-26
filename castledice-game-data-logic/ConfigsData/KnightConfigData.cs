using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic.Content.Placeable;

public sealed class KnightConfigData
{
    public int PlacementCost { get; }
    public int Health { get; }

    public KnightConfigData(int placementCost, int health)
    {
        PlacementCost = placementCost;
        Health = health;
    }

    private bool Equals(KnightConfigData other)
    {
        return PlacementCost == other.PlacementCost && Health == other.Health;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is KnightConfigData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PlacementCost, Health);
    }
}