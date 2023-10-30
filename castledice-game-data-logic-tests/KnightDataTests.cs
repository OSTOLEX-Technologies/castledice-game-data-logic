using castledice_game_data_logic.Content;
using static castledice_game_data_logic_tests.ObjectCreationUtility;
using Moq;

namespace castledice_game_data_logic_tests;

public class KnightDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitKnightData_OnVisitor()
    {
        var visitorMock = new Mock<IContentDataVisitor<int>>();
        var knightData = GetKnightData();
        
        knightData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitKnightData(knightData), Times.Once);
    }
}