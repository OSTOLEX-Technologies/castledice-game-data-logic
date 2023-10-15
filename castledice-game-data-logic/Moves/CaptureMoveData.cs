using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class CaptureMoveData : MoveData
{
    public override MoveType MoveType => MoveType.Capture;

    public CaptureMoveData(int playerId, Vector2Int position) : base(playerId, position)
    {
    }
}