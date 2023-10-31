using castledice_game_data_logic.Moves;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests;

public class ReplaceMoveDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitReplaceMoveData_OnVisitor()
    {
        var visitorMock = new Mock<IMoveDataVisitor<int>>();
        var replaceMoveData = GetReplaceMoveData();
        
        replaceMoveData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitReplaceMoveData(replaceMoveData), Times.Once);
    }
}