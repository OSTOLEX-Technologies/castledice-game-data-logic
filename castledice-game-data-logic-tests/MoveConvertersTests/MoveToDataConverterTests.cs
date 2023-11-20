using castledice_game_data_logic.MoveConverters;
using castledice_game_data_logic.Moves;
using castledice_game_logic.GameObjects;
using castledice_game_logic.MovesLogic;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests.MoveConvertersTests;

public class MoveToDataConverterTests
{
    [Theory]
    [MemberData(nameof(MoveToDataCases))]
    public void ConvertToData_ShouldReturnAppropriateMoveData_ForGivenMove(MoveData expectedMoveData, AbstractMove move)
    {
        var converter = new MoveToDataConverter();

        var actualMoveData = converter.ConvertToData(move);

        Assert.Equal(expectedMoveData, actualMoveData);
    }

    public static IEnumerable<object[]> MoveToDataCases()
    {
        yield return new object[]
        {
            GetRemoveMoveData(playerId: 3, x: 1, y: 2),
            new RemoveMoveBuilder
            {
                Player = GetPlayer(3),
                Position = (1, 2)
            }.Build()
        };
        yield return new object[]
        {
            GetCaptureMoveData(playerId: 4, x: 9, y: 9),
            new CaptureMoveBuilder
            {
                Player = GetPlayer(4),
                Position = (9, 9)
            }.Build()
        };
        yield return new object[]
        {
            GetUpgradeMoveData(playerId: 5, x: 3, y: 8),
            new UpgradeMoveBuilder
            {
                Player = GetPlayer(5),
                Position = (3, 8)
            }.Build()
        };
        yield return new object[]
        {
            GetPlaceMoveData(playerId: 6, x: 4, y: 5, placementType: PlacementType.Knight),
            new PlaceMoveBuilder
            {
                Player = GetPlayer(6),
                Position = (4, 5),
                Content = GetKnight(GetPlayer(4), health: 3, placementCost: 2)
            }.Build()
        };
        yield return new object[]
        {
            GetReplaceMoveData(playerId: 7, x: 6, y: 7, replacementType: PlacementType.Knight),
            new ReplaceMoveBuilder
            {
                Player = GetPlayer(7),
                Position = (6, 7),
                Replacement = GetKnight(GetPlayer(7), health: 3, placementCost: 2)
            }.Build()
        };
    }

}