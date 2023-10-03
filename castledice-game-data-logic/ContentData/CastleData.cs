namespace castledice_game_data_logic.ContentData;

[Serializable]
public class CastleData : ContentData
{
    public override ContentDataType Type => ContentDataType.Castle;
    
    public int FreeDurability { get; set; }
    public int DefaultDurability { get; set; }
    public int Durability { get; set; }
    public int OwnerId { get; set; }
}