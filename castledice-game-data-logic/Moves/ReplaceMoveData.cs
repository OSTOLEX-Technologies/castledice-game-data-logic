using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.Moves;

[Serializable]
public class ReplaceMoveData : MoveData
{
    public PlacementType ReplacementType { get; set; }
    public override MoveType MoveType => MoveType.Replace;

    public ReplaceMoveData(int playerId, Vector2Int position, PlacementType replacementType) : base(playerId, position)
    {
        ReplacementType = replacementType;
    }
}