using castledice_game_data_logic.Content;
using static castledice_game_data_logic_tests.ObjectCreationUtility;
using Moq;

namespace castledice_game_data_logic_tests;

public class TreeDataTests
{
    [Fact]
    public void Accept_ShouldCallVisitTreeData_OnVisitor()
    {
        var visitorMock = new Mock<IContentDataVisitor<int>>();
        var treeData = GetTreeData();
        
        treeData.Accept(visitorMock.Object);
        
        visitorMock.Verify(v => v.VisitTreeData(treeData), Times.Once);
    }
}