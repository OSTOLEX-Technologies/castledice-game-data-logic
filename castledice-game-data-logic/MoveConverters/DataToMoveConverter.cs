using castledice_game_data_logic.Moves;
using castledice_game_logic;
using castledice_game_logic.GameObjects.Factories;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MoveConverters;

public class DataToMoveConverter : IDataToMoveConverter, IMoveDataVisitor<AbstractMove>
{
    private readonly IPlaceablesFactory _placeablesFactory;

    public DataToMoveConverter(IPlaceablesFactory placeablesFactory)
    {
        _placeablesFactory = placeablesFactory;
    }

    public AbstractMove ConvertToMove(MoveData data, Player player)
    {
        throw new NotImplementedException();
    }

    public AbstractMove VisitRemoveMoveData(RemoveMoveData data)
    {
        throw new NotImplementedException();
    }

    public AbstractMove VisitPlaceMoveData(PlaceMoveData data)
    {
        throw new NotImplementedException();
    }

    public AbstractMove VisitUpgradeMoveData(UpgradeMoveData data)
    {
        throw new NotImplementedException();
    }

    public AbstractMove VisitReplaceMoveData(ReplaceMoveData data)
    {
        throw new NotImplementedException();
    }

    public AbstractMove VisitCaptureMoveData(CaptureMoveData data)
    {
        throw new NotImplementedException();
    }
}