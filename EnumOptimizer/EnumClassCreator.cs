﻿using EnumOptimizer.Models;
using EnumOptimizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumOptimizer
{
    public static class EnumClassCreator
    {
        private const string CLASS_NAMESPACE = "EnumOptimizer";
        public static string Create(EnumsModel model)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine($"namespace {CLASS_NAMESPACE}");
            sb.AppendLine("{");
            sb.AppendLine("public static class EnumExtensions", 1);
            sb.AppendLine("{", 1);
            foreach (var enumModel in model.Enums)
            {
                string fullName = $"global::{enumModel.NameSpace}.{enumModel.EnumName}";
                sb.AppendLine($"public static string FastToString(this {fullName} enumModel)", 2)
                    .AppendLine("{", 2)
                    .AppendLine("string result;", 3)
                    .AppendLine("switch (enumModel)", 3)
                    .AppendLine("{", 3);
                foreach (var member in enumModel.EnumMembers)
                {
                    string currentMember = $"{fullName}.{member}";
                    sb.AppendLine($"case {currentMember}:", 4);
                    sb.AppendLine($"result = nameof({currentMember});", 5);
                    sb.AppendLine("break;", 5);
                }
                sb.AppendLine("default:", 4);
                sb.AppendLine("throw new global::System.ArgumentOutOfRangeException(nameof(enumModel), enumModel, null);", 5);
                sb.AppendLine("}", 3);
                sb.AppendLine("return result;", 3);
                sb.AppendLine("}", 2);
                sb.AppendLine();
            }
            sb.AppendLine("}", 1);
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
