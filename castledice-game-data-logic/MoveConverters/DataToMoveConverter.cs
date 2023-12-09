using castledice_game_data_logic.Moves;
using castledice_game_logic;
using castledice_game_logic.GameObjects.Factories;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MoveConverters;

public class DataToMoveConverter : IDataToMoveConverter, IMoveDataVisitor<AbstractMove>
{
    public IPlaceablesFactory Factory => _placeablesFactory;
    
    private readonly IPlaceablesFactory _placeablesFactory;
    private Player _currentPlayer;

    public DataToMoveConverter(IPlaceablesFactory placeablesFactory)
    {
        _placeablesFactory = placeablesFactory;
    }

    public AbstractMove ConvertToMove(MoveData data, Player player)
    {
        if (data.PlayerId != player.Id)
        {
            throw new ArgumentException("Player id from data does not match the id of the given player.");
        }
        _currentPlayer = player;
        return data.Accept(this);
    }

    public AbstractMove VisitRemoveMoveData(RemoveMoveData data)
    {
        return new RemoveMove(_currentPlayer, data.Position);
    }

    public AbstractMove VisitPlaceMoveData(PlaceMoveData data)
    {
        return new PlaceMove(_currentPlayer, data.Position, _placeablesFactory.CreatePlaceable(data.PlacementType, _currentPlayer));
    }

    public AbstractMove VisitUpgradeMoveData(UpgradeMoveData data)
    {
        return new UpgradeMove(_currentPlayer, data.Position);
    }

    public AbstractMove VisitReplaceMoveData(ReplaceMoveData data)
    {
        return new ReplaceMove(_currentPlayer, data.Position, _placeablesFactory.CreatePlaceable(data.ReplacementType, _currentPlayer));
    }

    public AbstractMove VisitCaptureMoveData(CaptureMoveData data)
    {
        return new CaptureMove(_currentPlayer, data.Position);
    }
}