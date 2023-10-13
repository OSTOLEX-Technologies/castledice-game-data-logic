using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic.Content.Placeable;

public abstract class PlaceableContentData : ContentData
{
    public abstract PlacementType Type { get; }

    protected bool Equals(PlaceableContentData other)
    {
        return Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PlaceableContentData)obj);
    }

    public override int GetHashCode()
    {
        return (int)Type;
    }
}