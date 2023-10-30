namespace castledice_game_data_logic.ConfigsData;

public sealed class PlaceablesConfigData
{
    public KnightConfigData KnightConfig { get; }

    public PlaceablesConfigData(KnightConfigData knightConfig)
    {
        KnightConfig = knightConfig;
    }

    private bool Equals(PlaceablesConfigData other)
    {
        return KnightConfig.Equals(other.KnightConfig);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is PlaceablesConfigData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return KnightConfig.GetHashCode();
    }
}