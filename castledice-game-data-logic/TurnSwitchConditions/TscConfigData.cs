using castledice_game_logic.TurnsLogic.TurnSwitchConditions;

namespace castledice_game_data_logic.TurnSwitchConditions;

public sealed class TscConfigData
{
    public List<TscType> TscTypes { get; }

    public TscConfigData(List<TscType> tscTypes)
    {
        TscTypes = tscTypes;
    }

    private bool Equals(TscConfigData other)
    {
        return TscTypes.SequenceEqual(other.TscTypes);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is TscConfigData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return TscTypes.GetHashCode();
    }
}