using System.Collections.Generic;
using System.Text;

namespace Extensions;

public static class Extensions
{
    public static string GetNumerated<T>(this IEnumerable<T> ienumerable)
    {
        var sb = new StringBuilder();
        int i = 0;

        foreach (var item in ienumerable)
        {
            sb.Append(i + 1).Append(") ").Append(item).AppendLine();
            i++;
        }

        return sb.ToString();
    }

    public static bool InRange(this int value, int lower, int upper) => value >= lower && value <= upper;

    public static IReadOnlyAttributes Sum(this IEnumerable<IReadOnlyAttributes> attributes)
    {
        var result = Attributes.Zero;

        foreach (var attribute in attributes)
            result += (Attributes)attribute;

        return result;
    }
}
