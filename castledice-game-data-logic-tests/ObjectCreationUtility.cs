using System.Globalization;
using castledice_game_data_logic;
using castledice_game_data_logic.ConfigsData;
using castledice_game_data_logic.Content;
using castledice_game_data_logic.Errors;
using castledice_game_data_logic.Moves;
using castledice_game_data_logic.TurnSwitchConditions;
using castledice_game_logic;
using castledice_game_logic.ActionPointsLogic;
using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;
using castledice_game_logic.TurnsLogic.TurnSwitchConditions;
using Moq;

namespace castledice_game_data_logic_tests;

public static class ObjectCreationUtility
{
    public static TscConfigData GetTscConfigData()
    {
        return new TscConfigData(new List<TscType> { TscType.SwitchByActionPoints });
    }
    
    public static ErrorData GetErrorData()
    {
        return new ErrorData(ErrorType.GameNotSaved, "Game was not saved.");
    }
    
    public static Player GetPlayer(int id = 1)
    {
        return new Player(new PlayerActionPoints(), id);
    }
    
    public static GameStartData GetGameStartData()
    {
        var version = "1.0.0";
        var playerIds = new List<int>() { 1, 2 };
        var boardConfigData = GetBoardData();
        var placeablesConfigs = new PlaceablesConfigData(GetKnightConfigData());
        var playerDecks = new List<PlayerDeckData>()
        {
            new(playerIds[0], new List<PlacementType> { PlacementType.Knight }),
            new (playerIds[1], new List<PlacementType> { PlacementType.Knight })
        };
        var tscConfigData = new TscConfigData(new List<TscType> { TscType.SwitchByActionPoints });
        var data = new GameStartData(version, boardConfigData, placeablesConfigs, tscConfigData, playerIds, playerDecks);
        return data;
    }

    public static BoardData GetBoardData()
    {
        var boardLength = 10;
        var boardWidth = 10;
        var cellType = CellType.Square;
        var cellsPresence = GetNByNValuesMatrix(10, true);
        var firstCastle = new CastleData((0, 0), 1, 1, 3, 3, 1);
        var secondCastle = new CastleData((9, 9), 1, 1, 3, 3, 2);
        var generatedContent = new List<ContentData>
        {
            firstCastle, 
            secondCastle
        };
        return new BoardData(boardLength, boardWidth, cellType, cellsPresence, generatedContent);
    }

    public static GameData GetGameData()
    {
        var endTime = DateTime.Parse("2/27/2023 2:06:49", CultureInfo.InvariantCulture);
        var winnerId = 1;
        var history = "somehistory";
        var data = new GameData(1, "someconfig", DateTime.Parse("2/27/2023 2:06:49", CultureInfo.InvariantCulture), new List<int> { 1, 2 })
        {
            GameEndedTime = endTime,
            WinnerId = winnerId,
            History = history
        };
        return data;
    }

    public static KnightConfigData GetKnightConfigData()
    {
        return new KnightConfigData(1, 2);
    }
    
    public static CastleData GetCastleData()
    {
        return new CastleData((0, 0), 1, 1, 3, 3, 1);
    }

    public static TreeData GetTreeData()
    {
        return new TreeData((0, 0), 1, false);
    }
    
    public static KnightData GetKnightData()
    {
        return new KnightData((0, 0), 2, 1, 1);
    }
    
    public static Knight GetKnight(Player player, int health = 3, int placementCost = 1)
    {
        return new Knight(player, placementCost, health);
    }

    public static CaptureMoveData GetCaptureMoveData(int playerId = 1, int x = 1, int y = 1)
    {
        return new CaptureMoveData(playerId, (x, y));
    }

    public static PlaceMoveData GetPlaceMoveData(int playerId = 1, int x = 1, int y = 1, PlacementType placementType = PlacementType.Knight)
    {
        return new PlaceMoveData(playerId, (x, y), placementType);
    }

    public static RemoveMoveData GetRemoveMoveData(int playerId = 1, int x = 1, int y = 1)
    {
        return new RemoveMoveData(playerId, (x, y));
    }

    public static ReplaceMoveData GetReplaceMoveData(int playerId = 1, int x = 1, int y = 1, PlacementType replacementType = PlacementType.Knight)
    {
        return new ReplaceMoveData(playerId, (x, y), replacementType);
    }
    public static UpgradeMoveData GetUpgradeMoveData(int playerId = 1, int x = 1, int y = 1)
    {
        return new UpgradeMoveData(playerId, (x, y));
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
    
    public abstract class AbstractMoveBuilder
    {
        public Player Player = GetPlayer();
        public Vector2Int Position = new Vector2Int(0, 0);
    }
    
    public class PlaceMoveBuilder : AbstractMoveBuilder
    {

        public IPlaceable Content = GetPlaceable();
        
        public PlaceMove Build()
        {
            return new PlaceMove(Player, Position, Content);
        }
    }
    
    public class ReplaceMoveBuilder : AbstractMoveBuilder
    {
        public IPlaceable Replacement = GetPlaceable();
        
        public ReplaceMove Build()
        {
            return new ReplaceMove(Player, Position, Replacement);
        }
    }

    public class RemoveMoveBuilder : AbstractMoveBuilder
    {
        public RemoveMove Build()
        {
            return new RemoveMove(Player, Position);
        }
    }

    public class UpgradeMoveBuilder : AbstractMoveBuilder
    {
        public UpgradeMove Build()
        {
            return new UpgradeMove(Player, Position);
        }
    }

    public class CaptureMoveBuilder : AbstractMoveBuilder
    {
        public CaptureMove Build()
        {
            return new CaptureMove(Player, Position);
        }
    }
    public static IPlaceable GetPlaceable()
    {
        return new Mock<IPlaceable>().Object;
    }
    
}