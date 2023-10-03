namespace castledice_game_data_logic.ContentData;

public class TreeData : ContentData
{
    public override ContentDataType Type => ContentDataType.Tree;
    
    public int RemoveCost { get; set; }
    public bool CanBeRemoved { get; set; }
}