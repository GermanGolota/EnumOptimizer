using EnumOptimizer.Models;
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
            if (enumSyntax.Parent is NamespaceDeclarationSyntax nameSpace)
            {
                result = nameSpace.Name.ToString();
            }
            else
            {
                List<string> classNames = new List<string>();
                SyntaxNode parent = enumSyntax.Parent;
                while (parent is TypeDeclarationSyntax type && parent.Parent.IsNotNull())
                {
                    parent = parent.Parent;
                    classNames.Add(type.Identifier.Text);
                }
                string className = String.Join(".", classNames);
                var namespaceNode = TryGetNamespaceParent(parent);
                if (namespaceNode is NamespaceDeclarationSyntax syntax)
                {
                    result = $"{syntax.Name.ToString()}.{className}";
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }

        private static SyntaxNode TryGetNamespaceParent(SyntaxNode enumSyntax)
        {
            var parent = enumSyntax.Parent;
            if (enumSyntax is NamespaceDeclarationSyntax)
            {
                parent = enumSyntax;
            }
            else
            {
                while (parent.IsNotNull() && parent is NamespaceDeclarationSyntax == false && parent.Parent.IsNotNull())
                {
                    parent = parent.Parent;
                }
            }
            return parent;
        }
    }
}
