using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnumOptimizer.Utils
{
    public static class SyntaxUtils
    {
        public static string GetNamespaceOrNull(SyntaxNode enumSyntax)
        {
            string result;
            var parent = TryGetNamespaceParent(enumSyntax);
            if (parent is NamespaceDeclarationSyntax nameSpace)
            {
                result = nameSpace.Name.ToString();
            }
            else
            {
                result = null;
            }
            return result;
        }

        private static SyntaxNode TryGetNamespaceParent(SyntaxNode enumSyntax)
        {
            var parent = enumSyntax.Parent;
            while (parent.IsNotNull() && parent is NamespaceDeclarationSyntax == false && parent.Parent.IsNotNull())
            {
                parent = parent.Parent;
            }
            return parent;
        }
    }
}
