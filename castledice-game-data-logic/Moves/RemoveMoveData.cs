using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class RemoveMoveData : MoveData
{
    public override MoveType MoveType => MoveType.Remove;
    public override T Accept<T>(IMoveDataVisitor<T> visitor)
    {
        return visitor.VisitRemoveMoveData(this);
    }

    public RemoveMoveData(int playerId, Vector2Int position) : base(playerId, position)
    {
    }
}