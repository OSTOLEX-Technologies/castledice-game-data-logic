using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic.Content.Placeable;

public sealed class KnightData : PlaceableContentData
{
    public override PlacementType Type => PlacementType.Knight;
    
    public int PlacementCost { get; }
    public int Health { get; }

    public KnightData(int placementCost, int health)
    {
        PlacementCost = placementCost;
        Health = health;
    }

    private bool Equals(KnightData other)
    {
        return base.Equals(other) && PlacementCost == other.PlacementCost && Health == other.Health;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((KnightData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), PlacementCost, Health);
    }

    public override T Accept<T>(IContentDataVisitor<T> visitor)
    {
        return visitor.VisitKnightData(this);
    }
    
}