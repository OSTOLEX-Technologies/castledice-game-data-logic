using castledice_game_data_logic.Content;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests.ContentTests;

public class CastleDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitCastleData_OnVisitor()
    {
        var visitorMock = new Mock<IContentDataVisitor<int>>();
        var castleData = GetCastleData();
        
        castleData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitCastleData(castleData), Times.Once);
    }
}