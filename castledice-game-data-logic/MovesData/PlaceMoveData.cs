using castledice_game_logic.GameObjects;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MovesData;

public class PlaceMoveData : MoveData
{
    public PlacementType PlacementType { get; set; }
    public override MoveType MoveType => MoveType.Place;
}