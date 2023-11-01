using castledice_game_data_logic.MoveConverters;
using castledice_game_data_logic.Moves;
using castledice_game_logic;
using castledice_game_logic.GameObjects;
using castledice_game_logic.GameObjects.Factories;
using castledice_game_logic.MovesLogic;
using Moq;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests;

public class DataToMoveConverterTests
{
    [Fact]
    public void ConvertToMove_ShouldThrowArgumentException_IfGivenPlayerIdIsNotEqualToPlayerIdInData()
    {
        var factoryMock = new Mock<IPlaceablesFactory>();
        factoryMock.Setup(f => f.CreatePlaceable(It.IsAny<PlacementType>(), It.IsAny<Player>()))
            .Returns(new Mock<IPlaceable>().Object);
        var player = GetPlayer(1);
        var data = GetUpgradeMoveData(2);
        var converter = new DataToMoveConverter(factoryMock.Object);
        
        Assert.Throws<ArgumentException>(() => converter.ConvertToMove(data, player));
    }
    
    [Theory]
    [InlineData(1, 0, 0)]
    [InlineData(2, 1, 1)]
    [InlineData(3, 2, 2)]
    public void CreateMove_ShouldReturnAppropriateRemoveMove_IfGivenDataIsRemoveMoveData(int playerId, int x, int y)
    {
        var factoryMock = new Mock<IPlaceablesFactory>();
        factoryMock.Setup(f => f.CreatePlaceable(It.IsAny<PlacementType>(), It.IsAny<Player>()))
            .Returns(new Mock<IPlaceable>().Object);
        var player = GetPlayer(playerId);
        var data = GetRemoveMoveData(playerId, x, y);
        var converter = new DataToMoveConverter(factoryMock.Object);
        
        var move = converter.ConvertToMove(data, player);
        
        Assert.IsType<RemoveMove>(move);
        var removeMove = (RemoveMove) move;
        Assert.Same(player, removeMove.Player);
        Assert.Equal((x, y), removeMove.Position);
    }
    
    [Theory]
    [InlineData(1, 0, 0)]
    [InlineData(2, 1, 1)]
    [InlineData(3, 2, 2)]
    public void CreateMove_ShouldReturnAppropriateUpgradeMove_IfGivenDataIsUpgradeMoveData(int playerId, int x, int y)
    {
        var factoryMock = new Mock<IPlaceablesFactory>();
        factoryMock.Setup(f => f.CreatePlaceable(It.IsAny<PlacementType>(), It.IsAny<Player>()))
            .Returns(new Mock<IPlaceable>().Object);
        var player = GetPlayer(playerId);
        var data = GetUpgradeMoveData(playerId, x, y);
        var converter = new DataToMoveConverter(factoryMock.Object);
        
        var move = converter.ConvertToMove(data, player);
        
        Assert.IsType<UpgradeMove>(move);
        var upgradeMove = (UpgradeMove) move;
        Assert.Same(player, upgradeMove.Player);
        Assert.Equal((x, y), upgradeMove.Position);
    }

    [Theory]
    [InlineData(1, 0, 0)]
    [InlineData(2, 1, 1)]
    [InlineData(3, 2, 2)]
    public void CreateMove_ShouldReturnAppropriateCaptureMove_IfGivenDataIsCaptureMoveData(int playerId, int x, int y)
    {
        var factoryMock = new Mock<IPlaceablesFactory>();
        factoryMock.Setup(f => f.CreatePlaceable(It.IsAny<PlacementType>(), It.IsAny<Player>()))
            .Returns(new Mock<IPlaceable>().Object);
        var player = GetPlayer(playerId);
        var data = GetCaptureMoveData(playerId, x, y);
        var converter = new DataToMoveConverter(factoryMock.Object);
        
        var move = converter.ConvertToMove(data, player);
        
        Assert.IsType<CaptureMove>(move);
        var captureMove = (CaptureMove) move;
        Assert.Same(player, captureMove.Player);
        Assert.Equal((x, y), captureMove.Position);
    }

    [Theory]
    [InlineData(1, 0, 0, PlacementType.Knight)]
    [InlineData(2, 1, 1, PlacementType.Knight)]
    [InlineData(3, 2, 2, PlacementType.HeavyKnight)]
    //This test also checks if the factory is called with the correct placement type and player
    public void CreateMove_ShouldReturnAppropriatePlaceMove_IfGivenDataIsPlaceMoveData(int playerId, int x, int y,
        PlacementType placementType)
    {
        var factoryMock = new Mock<IPlaceablesFactory>();
        var contentToReturn = new Mock<IPlaceable>().Object;
        var player = GetPlayer(playerId);
        factoryMock.Setup(f => f.CreatePlaceable(placementType, player))
            .Returns(contentToReturn);
        var data = GetPlaceMoveData(playerId, x, y, placementType);
        var converter = new DataToMoveConverter(factoryMock.Object);
        
        var move = converter.ConvertToMove(data, player);
        
        Assert.IsType<PlaceMove>(move);
        var placeMove = (PlaceMove) move;
        Assert.Same(player, placeMove.Player);
        Assert.Equal((x, y), placeMove.Position);
        Assert.Same(contentToReturn, placeMove.ContentToPlace);
    }

    [Theory]
    [InlineData(1, 0, 0, PlacementType.Knight)]
    [InlineData(2, 1, 1, PlacementType.Knight)]
    [InlineData(3, 2, 2, PlacementType.HeavyKnight)]
    public void CreateMove_ShouldReturnAppropriateReplaceMove_IfGivenDataIsReplaceMoveData(int playerId, int x, int y,
        PlacementType replacementType)
    {
        var factoryMock = new Mock<IPlaceablesFactory>();
        var contentToReturn = new Mock<IPlaceable>().Object;
        var player = GetPlayer(playerId);
        factoryMock.Setup(f => f.CreatePlaceable(replacementType, player))
            .Returns(contentToReturn);
        var data = GetReplaceMoveData(playerId, x, y, replacementType);
        var converter = new DataToMoveConverter(factoryMock.Object);
        
        var move = converter.ConvertToMove(data, player);
        
        Assert.IsType<ReplaceMove>(move);
        var replaceMove = (ReplaceMove) move;
        Assert.Same(player, replaceMove.Player);
        Assert.Equal((x, y), replaceMove.Position);
        Assert.Same(contentToReturn, replaceMove.Replacement);
    }
}