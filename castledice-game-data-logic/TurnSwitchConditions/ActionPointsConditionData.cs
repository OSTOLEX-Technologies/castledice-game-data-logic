namespace castledice_game_data_logic.TurnSwitchConditions;

[Serializable]
public class ActionPointsConditionData : TscData
{
    public override TscType Type => TscType.ActionPoints;
    public override T Accept<T>(ITscDataVisitor<T> visitor)
    {
        return visitor.VisitActionPointsConditionData(this);
    }
}