using System.Globalization;
using castledice_game_data_logic;
using castledice_game_data_logic.Content.Generated;
using castledice_game_data_logic.Content.Placeable;
using castledice_game_data_logic.Moves;
using castledice_game_logic;
using castledice_game_logic.GameObjects;

namespace castledice_game_data_logic_tests;

public static class ObjectCreationUtility
{
    public static GameStartData GetGameStartData()
    {
        var boardLength = 10;
        var boardWidth = 10;
        var cellType = CellType.Square;
        var cellsPresence = GetNByNValuesMatrix(10, true);
        var playerIds = new List<int>() { 1, 2 };
        var firstCastle = new CastleData((0, 0), 1, 1, 3, 3, playerIds[0]);
        var secondCastle = new CastleData((9, 9), 1, 1, 3, 3, playerIds[1]);
        var generatedContent = new List<GeneratedContentData>
        {
            firstCastle, 
            secondCastle
        };
        var placeablesConfigs = new List<PlaceableContentData>
        {
            new KnightData(1, 2)
        };
        var playerDecks = new List<PlayerDeckData>()
        {
            new(playerIds[0], new List<PlacementType> { PlacementType.Knight }),
            new (playerIds[1], new List<PlacementType> { PlacementType.Knight })
        };
        var data = new GameStartData(boardLength, boardWidth, cellType, cellsPresence, generatedContent, placeablesConfigs, playerIds, playerDecks);
        return data;
    }

    public static GameData GetGameData()
    {
        return new GameData(1, "someconfig", DateTime.Parse("2/27/2023 2:06:49", CultureInfo.InvariantCulture), DateTime.Parse("2/27/2023 2:06:49", CultureInfo.InvariantCulture), 1, new List<int>{1, 2}, "somehistory");
    }

    public static KnightData GetKnightData()
    {
        return new KnightData(1, 2);
    }
    
    public static CastleData GetCastleData()
    {
        return new CastleData((0, 0), 1, 1, 3, 3, 1);
    }

    public static TreeData GetTreeData()
    {
        return new TreeData((0, 0), 3, false);
    }

    public static CaptureMoveData GetCaptureMoveData()
    {
        return new CaptureMoveData(1, (0, 0));
    }

    public static PlaceMoveData GetPlaceMoveData()
    {
        return new PlaceMoveData(1, (0, 0), PlacementType.Knight);
    }

    public static RemoveMoveData GetRemoveMoveData()
    {
        return new RemoveMoveData(1, (0, 0));
    }

    public static ReplaceMoveData GetReplaceMoveData()
    {
        return new ReplaceMoveData(1, (0, 0), PlacementType.Knight);
    }

    public static UpgradeMoveData GetUpgradeMoveData()
    {
        return new UpgradeMoveData(1, (0, 0));
    }

    public static PlayerDeckData GetPlayerDeckData() 
    {
        return new PlayerDeckData(1, new List<PlacementType>() { PlacementType.Knight });
    }
    
    public static T[,] GetNByNValuesMatrix<T>(int size, T value)
    {
        return GetValuesMatrix(size, size, value);
    }

    public static T[,] GetValuesMatrix<T>(int length, int width, T value)
    {
        var matrix = new T[length, width];
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                matrix[i, j] = value;
            }
        }

        return matrix;
    }
}