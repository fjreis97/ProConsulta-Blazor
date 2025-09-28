using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace ProConsulta.Extensions;

public static class StringExtensions
{
    public static string SomenteCacarteres(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        string pattern = @"[-\.\(\)\s]";

        string result = Regex.Replace(input, pattern, string.Empty);

        return result;
    }
}
