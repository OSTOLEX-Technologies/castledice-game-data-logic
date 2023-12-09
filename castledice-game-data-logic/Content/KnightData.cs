using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content;

[Serializable]
public sealed class KnightData : ContentData
{
    public override ContentDataType Type => ContentDataType.Knight;
    public int Health { get; }
    public int PlaceCost { get; }
    public int OwnerId { get; }

    public KnightData(Vector2Int position, int health, int placeCost, int ownerId) : base(position)
    {
        Health = health;
        PlaceCost = placeCost;
        OwnerId = ownerId;
    }

    public override T Accept<T>(IContentDataVisitor<T> visitor)
    {
        return visitor.VisitKnightData(this);
    }

    private bool Equals(KnightData other)
    {
        return base.Equals(other) && Health == other.Health && PlaceCost == other.PlaceCost && OwnerId == other.OwnerId;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is KnightData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Health, PlaceCost, OwnerId);
    }
}