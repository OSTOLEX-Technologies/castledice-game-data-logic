namespace castledice_game_data_logic.TurnSwitchConditions;

[Serializable]
public sealed class TimeConditionData : TscData
{
    public override TscType Type => TscType.Time;
    public int TurnDuration { get; }
    
    public TimeConditionData(int turnDuration)
    {
        TurnDuration = turnDuration;
    }

    private bool Equals(TimeConditionData other)
    {
        return base.Equals(other) && TurnDuration == other.TurnDuration;
    }
    
    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is TimeConditionData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), TurnDuration);
    }
}