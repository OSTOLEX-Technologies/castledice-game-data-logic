using castledice_game_logic.Math;

namespace castledice_game_data_logic.ContentData;

[Serializable]
public abstract class ContentData
{
    public Vector2Int Position { get; set; }
    public abstract ContentDataType Type { get; }
}