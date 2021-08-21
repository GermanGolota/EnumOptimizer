using System;
using System.Collections.Generic;
using System.Text;

namespace EnumOptimizer.Utils
{
    public static class StringBuilderUtils
    {
        public const string TAB = "    ";
        public static StringBuilder AppendLine(this StringBuilder sb, string text, int margin)
        {
            sb.AppendLine($"{Margin(margin)}{text}");
            return sb;
        }

        private static string Margin(int number)
        {
            StringBuilder marginBuilder = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                marginBuilder.Append(TAB);
            }
            return marginBuilder.ToString();
        }
    }
}
