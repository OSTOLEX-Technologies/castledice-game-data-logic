namespace castledice_game_data_logic.Extensions;

internal static class ArrayExtensions
{
    internal static bool SequenceEquals<T>(this T[,] a, T[,] b) => a.Rank == b.Rank
                                                                 && Enumerable.Range(0, a.Rank).All(d=> a.GetLength(d) == b.GetLength(d))
                                                                 && a.Cast<T>().SequenceEqual(b.Cast<T>());
}