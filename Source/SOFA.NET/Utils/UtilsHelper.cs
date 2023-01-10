namespace SOFA.NET;

internal static class UtilsHelper
{
    public static bool TryGetIndexHelper(Func<int> getIndex, out int index)
    {
        index = getIndex();
        return index >= 0;
    }

}
