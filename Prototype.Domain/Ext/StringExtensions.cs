using System.Text.RegularExpressions;

namespace Prototype.Domain.Ext {

    public static class StringExtensions {

        public static string RemoveSpecialCharacters(this string str) {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        public static string GetMeasurementType(this string str) {
            return Regex.Match(str, @"\(([^)]*)\)").Groups[1].Value;
        }
    }
}