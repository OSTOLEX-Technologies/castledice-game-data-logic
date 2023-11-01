using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public sealed class CaptureMoveData : MoveData
{
    public override MoveType MoveType => MoveType.Capture;
    public override T Accept<T>(IMoveDataVisitor<T> visitor)
    {
        return visitor.VisitCaptureMoveData(this);
    }

    public CaptureMoveData(int playerId, Vector2Int position) : base(playerId, position)
    {
    }
}