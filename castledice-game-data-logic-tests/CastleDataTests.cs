using castledice_game_data_logic.Content;
using static castledice_game_data_logic_tests.ObjectCreationUtility;
using Moq;

namespace castledice_game_data_logic_tests;

public class CastleDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitCastleData_OnVisitor()
    {
        var visitorMock = new Mock<IGeneratedContentDataVisitor<int>>();
        var castleData = GetCastleData();
        
        castleData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitCastleData(castleData), Times.Once);
    }
}