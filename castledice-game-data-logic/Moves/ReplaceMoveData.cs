using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class ReplaceMoveData : MoveData
{
    public PlacementType ReplacementType { get; }
    public override MoveType MoveType => MoveType.Replace;

    public ReplaceMoveData(int playerId, Vector2Int position, PlacementType replacementType) : base(playerId, position)
    {
        ReplacementType = replacementType;
    }

    protected bool Equals(ReplaceMoveData other)
    {
        return base.Equals(other) && ReplacementType == other.ReplacementType;
    }

    public override T Accept<T>(IMoveDataVisitor<T> visitor)
    {
        return visitor.VisitReplaceMoveData(this);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ReplaceMoveData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), (int)ReplacementType);
    }
}