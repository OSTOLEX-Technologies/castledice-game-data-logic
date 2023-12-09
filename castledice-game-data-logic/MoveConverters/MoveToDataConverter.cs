using castledice_game_data_logic.Moves;
using castledice_game_logic.MovesLogic;

namespace castledice_game_data_logic.MoveConverters;

public class MoveToDataConverter : IMoveToDataConverter, IMoveVisitor<MoveData>
{
    public MoveData ConvertToData(AbstractMove move)
    {
        return move.Accept(this);
    }

    public MoveData VisitPlaceMove(PlaceMove move)
    {
        return new PlaceMoveData(move.Player.Id, move.Position, move.ContentToPlace.PlacementType);
    }

    public MoveData VisitReplaceMove(ReplaceMove move)
    {
        return new ReplaceMoveData(move.Player.Id, move.Position, move.Replacement.PlacementType);
    }

    public MoveData VisitUpgradeMove(UpgradeMove move)
    {
        return new UpgradeMoveData(move.Player.Id, move.Position);
    }

    public MoveData VisitCaptureMove(CaptureMove move)
    {
        return new CaptureMoveData(move.Player.Id, move.Position);
    }

    public MoveData VisitRemoveMove(RemoveMove move)
    {
        return new RemoveMoveData(move.Player.Id, move.Position);
    }
}