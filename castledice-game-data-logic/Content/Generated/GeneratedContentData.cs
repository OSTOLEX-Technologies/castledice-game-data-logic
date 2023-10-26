using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content.Generated;

public abstract class GeneratedContentData
{
    public Vector2Int Position { get; }
    public abstract GeneratedContentDataType Type { get; }

    protected GeneratedContentData(Vector2Int position)
    {
        Position = position;
    }
    
    public abstract T Accept<T>(IGeneratedContentDataVisitor<T> visitor);
    
    protected bool Equals(GeneratedContentData other)
    {
        return Position.Equals(other.Position) && Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GeneratedContentData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position, (int)Type);
    }
}