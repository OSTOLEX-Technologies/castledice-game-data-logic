using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic;

[Serializable]
public class PlayerDeckData
{
    public int PlayerId { get; set; }
    public List<PlacementType> AvailablePlacements { get; set; }

    public PlayerDeckData(int playerId, List<PlacementType> availablePlacements)
    {
        PlayerId = playerId;
        AvailablePlacements = availablePlacements;
    }
}