using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content;

public abstract class ContentData
{
    public Vector2Int Position { get; }
    public abstract ContentDataType Type { get; }

    protected ContentData(Vector2Int position)
    {
        Position = position;
    }
    
    public abstract T Accept<T>(IContentDataVisitor<T> visitor);
    
    protected bool Equals(ContentData other)
    {
        return Position.Equals(other.Position) && Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ContentData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position, (int)Type);
    }
}