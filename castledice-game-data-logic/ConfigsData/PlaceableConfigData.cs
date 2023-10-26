using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic.Content.Placeable;

public abstract class PlaceableConfigData 
{
    public abstract PlacementType Type { get; }
    
    public abstract T Accept<T>(IPlaceableConfigDataVisitor<T> visitor);

    protected bool Equals(PlaceableConfigData other)
    {
        return Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PlaceableConfigData)obj);
    }

    public override int GetHashCode()
    {
        return (int)Type;
    }
}