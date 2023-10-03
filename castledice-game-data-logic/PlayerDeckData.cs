using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic;

[Serializable]
public class PlayerDeckData
{
    public int PlayerId { get; set; }
    public List<PlacementType> AvailablePlacements { get; } = new();
}