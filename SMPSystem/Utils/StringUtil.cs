using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMPSystem.Utils
{
    public static class StringUtil
    {
        public const string SingleQuote = "\'";
        public const string DefaultEllipsis = "...";
        public const int DefaultLimitSearchBreak = 7;


        public static string NullTo(this string source) => NullTo(source, "");
        public static string NullTo(this string source, string textDefault)
        {
            if (string.IsNullOrWhiteSpace(source))
                return textDefault;
            return source;
        }
        public static string EmptyToNull(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;
            return source;
        }
        public static string EmptyTo(this string source, string textDefault)
        {
            if (string.IsNullOrWhiteSpace(source))
                return textDefault;
            return source;
        }
        public static bool HasValue(this string source)
        => !string.IsNullOrWhiteSpace(source);
        public static bool IsIn(this string source, params string[] options)
        {
            if (options == null) return false;
            return options.Contains(source);
        }

        public static string GetLast(this string source, int tailLength)
        {
            if (tailLength >= source.Length)
                return source;
            if (tailLength < 1)
                return string.Empty;
            return source[^tailLength..];
        }
        public static string GetLast(this string source, string separator)
        {
            int from = source.LastIndexOf(separator) + 1;
            return source[from..];
        }
        public static string GetFirst(this string source, int startLength)
        {
            if (startLength >= source.Length)
                return source;
            return source.Substring(0, startLength);
        }
        public static string TrySubstring(this string source, int startIndex)
        {
            if (startIndex > source.Length)
                return source;
            return source[startIndex..];
        }
        public static string TrySubstring(this string source, int startIndex, int length)
        {
            if (startIndex > source.Length)
                return source;
            if (source.Length < startIndex + length)
                length = source.Length - startIndex;
            return source.Substring(startIndex, length);
        }



        public static string EscapeSingleQuotes(this string text)
            => text.Replace(SingleQuote, SingleQuote + SingleQuote);
        public static int ToIntOr(this string text, int fallback)
            => int.TryParse(text, out int parsed) ? parsed : fallback;
        public static string CropText(this string text, int size)
            => CropText(text, size, DefaultLimitSearchBreak, DefaultEllipsis);
        public static string CropText(this string text, int size, int limitSearchBreak, string ellipsis)
        {
            text ??= string.Empty;
            if (text.Length <= size) return text;
            for (int i = 0; i < limitSearchBreak; i++)
            {
                int pos = size - ellipsis.Length - i;
                if (!char.IsLetterOrDigit(text[pos]))
                {
                    return text.Substring(0, pos) + ellipsis;
                }
            }
            return text.Substring(0, size - ellipsis.Length) + ellipsis;
        }



        public static string ReplaceSpecialChar(this string input)
        {
            var temp = input.Normalize(NormalizationForm.FormD);
            IEnumerable<char> filtered = temp;
            filtered = filtered.Where(c =>
                char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark
                && !char.IsSymbol(c));
            return new string(filtered.ToArray());
        }


        public static string RandomChars(string chars, int outputsize)
        {
            if (outputsize < 0) throw new ArgumentOutOfRangeException("ouput size must be a positive number");
            Random rand = new Random();
            string result = string.Empty;
            while (result.Length < outputsize)
            {
                int num = rand.Next(0, chars.Length - 1);
                result += chars[num];
            }
            return result;
        }
        /// <summary>
        /// Replace every char that is not Letter Or Digit Or Exception
        /// with the substitute char
        /// </summary>
        public static string ReplaceNonRegularWith(this string input, char substitute, string exceptions = null)
        {
            exceptions ??= string.Empty;
            var x = input.ToList();
            var filtered = new List<char>(x.Count);
            x.ForEach(c => filtered.Add(exceptions.Contains(c) || char.IsLetterOrDigit(c) ? c : substitute));
            return new string(filtered.ToArray());
        }
    }
}
