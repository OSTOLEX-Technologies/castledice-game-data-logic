using castledice_game_data_logic.Content.Placeable;
using static castledice_game_data_logic_tests.ObjectCreationUtility;
using Moq;

namespace castledice_game_data_logic_tests;

public class KnightConfigDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitKnightConfigData_OnVisitor()
    {
        var visitorMock = new Mock<IPlaceableConfigDataVisitor<int>>();
        var knightData = GetKnightData();
        
        knightData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitKnightConfigData(knightData), Times.Once);
    }
}