using castledice_game_data_logic.Moves;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests;

public class CaptureMoveDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitTreeData_OnVisitor()
    {
        var visitorMock = new Mock<IMoveDataVisitor<int>>();
        var captureMoveData = GetCaptureMoveData();
        
        captureMoveData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitCaptureMoveData(captureMoveData), Times.Once);
    }
}