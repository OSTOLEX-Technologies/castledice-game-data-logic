using castledice_game_data_logic.TurnSwitchConditions;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests.TurnSwitchConditionsTests;

public class TimeConditionDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitTimeConditionData_OnVisitor()
    {
        var visitorMock = new Mock<ITscDataVisitor<int>>();
        var timeConditionData = GetTimeConditionData();
        
        timeConditionData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitTimeConditionData(timeConditionData), Times.Once);
    }
}