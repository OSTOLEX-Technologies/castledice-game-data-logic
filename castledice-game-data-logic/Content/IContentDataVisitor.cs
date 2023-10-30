namespace castledice_game_data_logic.Content;

public interface IContentDataVisitor<out T>
{
    public T VisitCastleData(CastleData data);
    public T VisitTreeData(TreeData data);
    public T VisitKnightData(KnightData data);
}