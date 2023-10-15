using castledice_game_data_logic.Extensions;
using static castledice_game_data_logic_tests.ObjectCreationUtility;

namespace castledice_game_data_logic_tests;

public static class Array2DExtensionsTests
{
    [Theory]
    [InlineData(10, 9, 8, 7, true)]
    [InlineData(1, 2, 3, 4, "test")]
    [InlineData(10, 8, 10, 7, "test")]
    public static void Equals2D_ShouldReturnFalse_IfMatricesSizesAreDifferent<T>(int firstArrayLength,
        int firstArrayWidth, int secondArrayLength, int secondArrayWidth, T content)
    {
        var first2DArray = GetValuesMatrix(firstArrayLength, firstArrayWidth, content);
        var second2DArray = GetValuesMatrix(secondArrayLength, secondArrayWidth, content);
        
        Assert.False(first2DArray.Equals2D(second2DArray));  
    }

    [Fact]
    public static void Equals2D_ShouldReturnFalse_IfMatricesContentsAreDifferent()
    {
        var firstMatrix = new [,]
        {
            { "test", "test" },
            {"test", "notTest"}
        };
        var secondMatrix = new[,]
        {
            { "test", "test" },
            { "test", "test" }
        };
        
        Assert.False(firstMatrix.Equals2D(secondMatrix));
    }

    [Fact]
    public static void Equals2D_ShouldReturnFalse_IfNullsDoNotMatch()
    {
        var firstMatrix = new [,]
        {
            { null, "test" },
            { "test", "test" }
        };
        var secondMatrix = new[,]
        {
            { "test", "test" },
            { "test", null }
        };
        
        Assert.False(firstMatrix.Equals2D(secondMatrix));
    }
    
    [Fact]
    public static void Equals2D_ShouldReturnTrue_IfNullsMatch()
    {
        var firstMatrix = new [,]
        {
            { "test", "test" },
            { "test", null }
        };
        var secondMatrix = new[,]
        {
            { "test", "test" },
            { "test", null }
        };
        
        Assert.True(firstMatrix.Equals2D(secondMatrix));
    }
    
    [Theory]
    [InlineData(10, true)]
    [InlineData(10, false)]
    [InlineData(10, 1)]
    [InlineData(5, "test")]
    [InlineData(1, 'a')]
    public static void Equals2D_ShouldReturnTrue_IfTwoArraysHaveEqualContent<T>(int matrixSize, T content)
    {
        var first2DArray = GetNByNValuesMatrix(matrixSize, content);
        var second2DArray = GetNByNValuesMatrix(matrixSize, content);
        
        Assert.True(first2DArray.Equals2D(second2DArray));
    }
}