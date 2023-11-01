using castledice_game_data_logic.Moves;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MoveConverters;

public interface IMoveToDataConverter
{
    MoveData ConvertToData(AbstractMove move);
}