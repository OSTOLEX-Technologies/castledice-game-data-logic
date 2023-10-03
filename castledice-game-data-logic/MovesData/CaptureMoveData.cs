using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MovesData;

[Serializable]
public class CaptureMoveData : MoveData
{
    public override MoveType MoveType => MoveType.Capture;
}