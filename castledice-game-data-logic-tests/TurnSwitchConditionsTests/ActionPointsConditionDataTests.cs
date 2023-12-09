using castledice_game_data_logic.TurnSwitchConditions;
using static castledice_game_data_logic_tests.ObjectCreationUtility;
using Moq;

namespace castledice_game_data_logic_tests.TurnSwitchConditionsTests;

public class ActionPointsConditionDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitActionPointsConditionData_OnVisitor()
    {
        var visitorMock = new Mock<ITscDataVisitor<int>>();
        var actionPointsConditionData = GetActionPointsConditionData();
        
        actionPointsConditionData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitActionPointsConditionData(actionPointsConditionData), Times.Once);
    }
}