using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class PlaceMoveData : MoveData
{
    public PlacementType PlacementType { get; set; }
    public override MoveType MoveType => MoveType.Place;

    public PlaceMoveData(int playerId, Vector2Int position, PlacementType placementType) : base(playerId, position)
    {
        PlacementType = placementType;
    }
}