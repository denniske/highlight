using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Highlight.Patterns
{
    public sealed class BlockPattern : Pattern
    {
        public string BeginsWith { get; private set; }
        public string EndsWith { get; private set; }
        public string EscapesWith { get; private set; }
        public bool IncludePatternTags { get; set; }

        public BlockPattern(string name, Style style, string beginsWith, string endsWith, string escapesWith, bool includePatternTags)
            : base(name, style)
        {
            BeginsWith = beginsWith;
            EndsWith = endsWith;
            EscapesWith = escapesWith;
            IncludePatternTags = includePatternTags;
        }

        public override string GetRegexPattern()
        {
            if (String.IsNullOrEmpty(EscapesWith))
            {
                if (EndsWith.CompareTo(@"\n") == 0)
                {
                    return FormatPattern(String.Format(@"{0}[^\n\r]*", Escape(BeginsWith)));
                }
                return FormatPattern(String.Format(@"{0}[\w\W\s\S]*?{1}", Escape(BeginsWith), Escape(EndsWith)));
            }

            string pattern = String.Format("{0}(?>{1}.|[^{2}]|.)*?{3}", new object[] { Regex.Escape(BeginsWith), Regex.Escape(EscapesWith.Substring(0, 1)), Regex.Escape(EndsWith.Substring(0, 1)), Regex.Escape(EndsWith) });
            return FormatPattern(pattern);

        }

        private string FormatPattern(string pattern)
        {
                return string.Format("(?'{0}'{1})", Name, pattern);
        }

        public static string Escape(string str)
        {
            if (str.CompareTo(@"\n") != 0)
            {
                str = Regex.Escape(System.Net.WebUtility.HtmlEncode(str));
            }
            return str;
        }
    }
}