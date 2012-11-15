using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Text;

namespace MattBaines.Helpers
{
    public class HtmlHelpers
    {
        public static string SplitCamelCase(string str)
        {
            return Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
        }

        public static string Truncate(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            return input.Substring(0, length) + "...";
        }

        public static string ListToFormattedString(List<string> list)
        {
            StringBuilder temp = new StringBuilder();
            int index = 0;
            foreach (var item in list)
            {
                index++;
                temp.Append(item);
                if(index != list.Count)
                    temp.Append(", ");
            }
            return temp.ToString();
        }
    }
}