namespace castledice_game_data_logic.TurnSwitchConditions;

/// <summary>
/// Tsc stands for Turn Switch Condition.
/// </summary>
[Serializable]
public abstract class TscData
{
    public abstract TscType Type { get; }

    protected bool Equals(TscData other)
    {
        return Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((TscData)obj);
    }

    public override int GetHashCode()
    {
        return (int)Type;
    }
}