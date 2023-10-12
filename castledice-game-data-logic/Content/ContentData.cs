using castledice_game_logic.Math;

namespace castledice_game_data_logic.Content;

[Serializable]
public abstract class ContentData
{
    public abstract T Accept<T>(IContentDataVisitor<T> visitor);
    
}