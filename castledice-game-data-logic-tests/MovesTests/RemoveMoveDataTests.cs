using castledice_game_data_logic.Moves;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests.MovesTests;

public class RemoveMoveDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitRemoveMoveData_OnVisitor()
    {
        var visitorMock = new Mock<IMoveDataVisitor<int>>();
        var removeMoveData = GetRemoveMoveData();
        
        removeMoveData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitRemoveMoveData(removeMoveData), Times.Once);
    }
}