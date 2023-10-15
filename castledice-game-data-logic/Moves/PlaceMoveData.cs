using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class PlaceMoveData : MoveData
{
    public PlacementType PlacementType { get; }
    public override MoveType MoveType => MoveType.Place;

    public PlaceMoveData(int playerId, Vector2Int position, PlacementType placementType) : base(playerId, position)
    {
        PlacementType = placementType;
    }

    protected bool Equals(PlaceMoveData other)
    {
        return base.Equals(other) && PlacementType == other.PlacementType;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PlaceMoveData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), (int)PlacementType);
    }
}