using EnumOptimizer.Models;
using EnumOptimizer.Utils;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumOptimizer
{
    public static class EnumsModelCollector
    {
        public static EnumsModel Collect(List<EnumDeclarationSyntax> syntaxes)
        {
            List<EnumModel> enums = new List<EnumModel>();
            foreach (var syntax in syntaxes)
            {
                var model = new EnumModel
                {
                    EnumName = syntax.Identifier.Text,
                    EnumMembers = syntax.Members
                                .Select(x => x.Identifier.Text)
                                .ToList(),
                    NameSpace = SyntaxUtils.GetNamespaceOrNull(syntax)
                };
                enums.Add(model);
            }

            return new EnumsModel
            {
                Enums = enums
            };
        }
    }
}
