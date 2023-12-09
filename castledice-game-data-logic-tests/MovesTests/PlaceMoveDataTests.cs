using castledice_game_data_logic.Moves;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests.MovesTests;

public class PlaceMoveDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitPlaceMoveData_OnVisitor()
    {
        var visitorMock = new Mock<IMoveDataVisitor<int>>();
        var placeMoveData = GetPlaceMoveData();
        
        placeMoveData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitPlaceMoveData(placeMoveData), Times.Once);
    }
}