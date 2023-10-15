using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("castledice-game-data-logic-tests")]
namespace castledice_game_data_logic.Extensions;

internal static class Array2DExtensions
{
    internal static bool Equals2D<T>(this T[,] a, T[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0)) return false;
        if (a.GetLength(1) != b.GetLength(1)) return false;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] is null != b[i, j] is null) //This is statement works as XOR operator. If one of objects is null and another is not, than arrays are not equal.
                {
                    return false;
                }
                if (a[i, j] is null && b[i, j] is null)
                {
                    continue;
                }
                if (!a[i, j]!.Equals(b[i, j]))
                {
                    return false;
                }
            }
        }
        return true;
    }

}