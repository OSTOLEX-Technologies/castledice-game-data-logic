using castledice_game_data_logic.TurnSwitchConditions;
using castledice_game_logic.TurnsLogic.TurnSwitchConditions;

namespace castledice_game_data_logic_tests.TurnSwitchConditionsTests;

public class TscConfigDataTests
{
    [Fact]
    public void Properties_ShouldReturnValues_GivenInConstructor()
    {
        var tscTypes = new List<TscType> { TscType.SwitchByActionPoints };
        var tscConfigData = new TscConfigData(tscTypes);
        
        Assert.Equal(tscTypes, tscConfigData.TscTypes);
    }
}