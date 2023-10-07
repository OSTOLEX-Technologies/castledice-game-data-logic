using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content;

[Serializable]
public class TreeData : ContentData
{
    public override ContentDataType Type => ContentDataType.Tree;
    
    public int RemoveCost { get; set; }
    public bool CanBeRemoved { get; set; }

    public TreeData(Vector2Int position, int removeCost, bool canBeRemoved) : base(position)
    {
        RemoveCost = removeCost;
        CanBeRemoved = canBeRemoved;
    }
}