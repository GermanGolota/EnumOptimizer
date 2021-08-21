using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnumOptimizer.Tests
{
    public class SourceGeneratorTests
    {
        [Fact]
        public void Execute_ShouldNotThrow_WhenRequestsExist()
        {
            //Arrange
            List<string> sources = new List<string>
            {
                @"
using System;

namespace EnumOptimizer.Tests
{
    public enum Role
    {
        Admin, User
    }
}
",
                @"
using System;

namespace EnumOptimizer.Tests.Types
{
    public enum MediaType
    {
        Image, Video
    }
}
"
            };
            Compilation inputCompilation = CreateCompilation(sources);
            SourceGenerator generator = new SourceGenerator();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);
            //Act
            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);
            GeneratorDriverRunResult _ = driver.GetRunResult();
            //Assert
            //do not throws
        }

        private static Compilation CreateCompilation(List<string> sources)
        {
            return CSharpCompilation.Create("compilation",
                sources.Select(source => CSharpSyntaxTree.ParseText(source)),
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
        }
    }
}
