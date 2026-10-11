using System;
using System.Globalization;

namespace CssSaison.Services
{
    internal static class SeasonDateHelper
    {
        private static readonly string[] Formats = { "dd-MM", "d-M", "dd/MM", "d/M" };

        public static bool TryParseDdMm(string value, int year, out DateTime date)
        {
            date = default;
            if (string.IsNullOrWhiteSpace(value))
                return false;

            value = value.Trim();
            if (!DateTime.TryParseExact(value, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
                return false;

            try
            {
                date = new DateTime(year, parsed.Month, parsed.Day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDdMm(string value) => TryParseDdMm(value, 2000, out _);

        public static string FormatPeriod(string startDdMm, string endDdMm)
        {
            var start = (startDdMm ?? string.Empty).Trim();
            var end = (endDdMm ?? string.Empty).Trim();
            if (start.Length == 0 && end.Length == 0)
                return string.Empty;
            return start + " → " + end;
        }

        /// <summary>
        /// Accepte "01-02 → 15-02", "01-02 -> 15-02", "01-02 / 15-02".
        /// </summary>
        public static bool TryParsePeriod(string period, out string startDdMm, out string endDdMm)
        {
            startDdMm = null;
            endDdMm = null;
            if (string.IsNullOrWhiteSpace(period))
                return false;

            var s = period.Trim();
            string[] seps = { "→", "->", "/", "—" };
            foreach (var sep in seps)
            {
                var idx = s.IndexOf(sep, StringComparison.Ordinal);
                if (idx < 0)
                    continue;

                var left = s.Substring(0, idx).Trim();
                var right = s.Substring(idx + sep.Length).Trim();
                if (!IsValidDdMm(left) || !IsValidDdMm(right))
                    return false;

                startDdMm = left;
                endDdMm = right;
                return true;
            }

            return false;
        }

        public static bool IsInRange(DateTime today, string startDdMm, string endDdMm)
        {
            if (!TryParseDdMm(startDdMm, today.Year, out var start) ||
                !TryParseDdMm(endDdMm, today.Year, out var end))
            {
                return false;
            }

            if (end < start)
                return today >= start || today <= end;

            return today >= start && today <= end;
        }
    }
}
