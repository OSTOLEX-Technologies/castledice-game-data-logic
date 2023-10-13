using static castledice_game_data_logic_tests.ObjectCreationUtility;
namespace castledice_game_data_logic_tests;

public class EqualsTests
{
    
    [Theory]
    [MemberData(nameof(EqualsTestCases))]
    public void Equals_ShouldReturnTrue_IfTwoInstancesAreEqual<T>(Func<T> instanceProviderFunction)
    {
        var instance1 = instanceProviderFunction();
        var instance2 = instanceProviderFunction();
        
        Assert.Equal(instance1, instance2);
    }

    public static IEnumerable<object[]> EqualsTestCases()
    {
        yield return new[]
        {
            GetCastleData
        };
        yield return new[]
        {
            GetTreeData
        };
        yield return new[]
        {
            GetCaptureMoveData
        };
        yield return new[]
        {
            GetPlaceMoveData
        };
        yield return new[]
        {
            GetRemoveMoveData
        };
        yield return new[]
        {
            GetReplaceMoveData
        };
        yield return new[]
        {
            GetUpgradeMoveData
        };
        yield return new[]
        {
            GetGameStartData
        };
        yield return new[]
        {
            GetPlayerDeckData
        };
        yield return new[]
        {
            GetKnightData
        };
        yield return new[]
        {
            GetGameData
        };
    }
}