using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content;

[Serializable]
public sealed class TreeData : ContentData
{
    public override ContentDataType Type => ContentDataType.Tree;
    
    public int RemoveCost { get; }
    public bool CanBeRemoved { get; }

    public TreeData(Vector2Int position, int removeCost, bool canBeRemoved) : base(position)
    {
        RemoveCost = removeCost;
        CanBeRemoved = canBeRemoved;
    }

    protected bool Equals(TreeData other)
    {
        return base.Equals(other) && RemoveCost == other.RemoveCost && CanBeRemoved == other.CanBeRemoved;
    }

    public override T Accept<T>(IContentDataVisitor<T> visitor)
    {
        return visitor.VisitTreeData(this);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((TreeData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), RemoveCost, CanBeRemoved);
    }
}