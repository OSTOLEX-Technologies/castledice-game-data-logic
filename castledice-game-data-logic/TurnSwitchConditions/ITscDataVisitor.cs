namespace castledice_game_data_logic.TurnSwitchConditions;

public interface ITscDataVisitor<out T>
{
   T VisitActionPointsConditionData(ActionPointsConditionData data);
   T VisitTimeConditionData(TimeConditionData data);
}