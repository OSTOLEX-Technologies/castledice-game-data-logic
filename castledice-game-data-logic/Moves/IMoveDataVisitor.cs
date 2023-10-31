namespace castledice_game_data_logic.Moves;

public interface IMoveDataVisitor<out T>
{
    T VisitRemoveMoveData(RemoveMoveData data);
    T VisitPlaceMoveData(PlaceMoveData data);
    T VisitUpgradeMoveData(UpgradeMoveData data);
    T VisitReplaceMoveData(ReplaceMoveData data);
    T VisitCaptureMoveData(CaptureMoveData data);
}