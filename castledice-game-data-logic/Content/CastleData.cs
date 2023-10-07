using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content;

[Serializable]
public class CastleData : ContentData
{
    public override ContentDataType Type => ContentDataType.Castle;
    
    public int CastleCaptureCost { get; set; }
    public int FreeDurability { get; set; }
    public int DefaultDurability { get; set; }
    public int Durability { get; set; }
    public int OwnerId { get; set; }

    public CastleData(Vector2Int position, int castleCaptureCost, int freeDurability, int defaultDurability, int durability, int ownerId) : base(position)
    {
        CastleCaptureCost = castleCaptureCost;
        FreeDurability = freeDurability;
        DefaultDurability = defaultDurability;
        Durability = durability;
        OwnerId = ownerId;
    }
}