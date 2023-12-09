using castledice_game_data_logic.Moves;
using castledice_game_logic;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MoveConverters;

public interface IDataToMoveConverter
{
    AbstractMove ConvertToMove(MoveData data, Player player);
}