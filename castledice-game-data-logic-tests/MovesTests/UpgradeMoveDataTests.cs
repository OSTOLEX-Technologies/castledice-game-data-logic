using castledice_game_data_logic.Moves;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests.MovesTests;

public class UpgradeMoveDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitUpgradeMoveData_OnVisitor()
    {
        var visitorMock = new Mock<IMoveDataVisitor<int>>();
        var upgradeMoveData = GetUpgradeMoveData();
        
        upgradeMoveData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitUpgradeMoveData(upgradeMoveData), Times.Once);
    }
}