using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MovesData;

[Serializable]
public abstract class MoveData
{
    public int PlayerId { get; set; }
    public Vector2Int Position { get; set; }
    public abstract MoveType MoveType { get; }
}