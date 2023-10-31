using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class UpgradeMoveData : MoveData
{
    public override MoveType MoveType => MoveType.Upgrade;
    public override T Accept<T>(IMoveDataVisitor<T> visitor)
    {
        return visitor.VisitUpgradeMoveData(this);
    }

    public UpgradeMoveData(int playerId, Vector2Int position) : base(playerId, position)
    {
    }
}