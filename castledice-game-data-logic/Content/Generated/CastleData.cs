using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content.Generated;

[Serializable]
public sealed class CastleData : GeneratedContentData
{
    public override GeneratedContentDataType Type => GeneratedContentDataType.Castle;
    
    public int CastleCaptureHitCost { get;  }
    public int FreeDurability { get; }
    public int DefaultDurability { get; }
    public int Durability { get; }
    public int OwnerId { get; }

    public CastleData(Vector2Int position, int castleCaptureHitCost, int freeDurability, int defaultDurability, int durability, int ownerId) : base(position)
    {
        CastleCaptureHitCost = castleCaptureHitCost;
        FreeDurability = freeDurability;
        DefaultDurability = defaultDurability;
        Durability = durability;
        OwnerId = ownerId;
    }

    private bool Equals(CastleData other)
    {
        return base.Equals(other) && CastleCaptureHitCost == other.CastleCaptureHitCost && FreeDurability == other.FreeDurability && DefaultDurability == other.DefaultDurability && Durability == other.Durability && OwnerId == other.OwnerId;
    }

    public override T Accept<T>(IContentDataVisitor<T> visitor)
    {
        return visitor.VisitCastleData(this);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CastleData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), CastleCaptureHitCost, FreeDurability, DefaultDurability, Durability, OwnerId);
    }
}