using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public abstract class MoveData
{
    public int PlayerId { get; }
    public Vector2Int Position { get; }
    public abstract MoveType MoveType { get; }

    protected MoveData(int playerId, Vector2Int position)
    {
        PlayerId = playerId;
        Position = position;
    }

    protected bool Equals(MoveData other)
    {
        return PlayerId == other.PlayerId && Position.Equals(other.Position) && MoveType == other.MoveType;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MoveData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PlayerId, Position, (int)MoveType);
    }
}