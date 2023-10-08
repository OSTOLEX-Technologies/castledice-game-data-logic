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
        
        Assert.True(instance1.Equals(instance2));
    }

    public static IEnumerable<object[]> EqualsTestCases()
    {
        yield return new object[]
        {
            () => GetCastleData()
        };
        yield return new object[]
        {
            () => GetTreeData()
        };
        yield return new object[]
        {
            () => GetCaptureMoveData()
        };
        yield return new object[]
        {
            () => GetPlaceMoveData()
        };
        yield return new object[]
        {
            () => GetRemoveMoveData()
        };
        yield return new object[]
        {
            () => GetReplaceMoveData()
        };
        yield return new object[]
        {
            () => GetUpgradeMoveData()
        };
        yield return new object[]
        {
            () => GetGameStartData()
        };
        yield return new object[]
        {
            () => GetPlayerDeckData()
        };
    }
}