using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content;

[Serializable]
public sealed class CastleData : ContentData
{
    public override ContentDataType Type => ContentDataType.Castle;
    
    public int CaptureHitCost { get;  }
    public int MaxFreeDurability { get; }
    public int MaxDurability { get; }
    public int Durability { get; }
    public int OwnerId { get; }

    public CastleData(Vector2Int position, int captureHitCost, int maxFreeDurability, int maxDurability, int durability, int ownerId) : base(position)
    {
        CaptureHitCost = captureHitCost;
        MaxFreeDurability = maxFreeDurability;
        MaxDurability = maxDurability;
        Durability = durability;
        OwnerId = ownerId;
    }

    private bool Equals(CastleData other)
    {
        return base.Equals(other) && CaptureHitCost == other.CaptureHitCost && MaxFreeDurability == other.MaxFreeDurability && MaxDurability == other.MaxDurability && Durability == other.Durability && OwnerId == other.OwnerId;
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
        return HashCode.Combine(base.GetHashCode(), CaptureHitCost, MaxFreeDurability, MaxDurability, Durability, OwnerId);
    }
}