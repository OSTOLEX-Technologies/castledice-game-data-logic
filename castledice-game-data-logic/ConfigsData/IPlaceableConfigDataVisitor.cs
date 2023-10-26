namespace castledice_game_data_logic.Content.Placeable;

public interface IPlaceableConfigDataVisitor<out T>
{
    public T VisitKnightConfigData(KnightConfigData configData);

}