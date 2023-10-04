namespace castledice_game_data_logic.Content;

[Serializable]
public class TreeData : ContentData
{
    public override ContentDataType Type => ContentDataType.Tree;
    
    public int RemoveCost { get; set; }
    public bool CanBeRemoved { get; set; }
}