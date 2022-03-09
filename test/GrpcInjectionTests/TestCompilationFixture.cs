using GrpcInjection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Reflection;
using Xunit;

namespace GrpcInjectionTests
{
    public  class TestCompilationFixture
    {
     
        private  Compilation CreateCompilation(string source)
            => CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));

        public  string GetCompilationOutput(string source)
        {
            var compilation = CreateCompilation(source);
            ISourceGenerator generator = new Generator();
            var driver = CSharpGeneratorDriver.Create(generator);

            driver.RunGeneratorsAndUpdateCompilation(compilation, out var output, out var diagnostic);

            Assert.False(diagnostic.Any(d => d.Severity == DiagnosticSeverity.Error), $"Failed:{diagnostic.FirstOrDefault()?.GetMessage()}");

            string outputCompilation = output.SyntaxTrees.Last().ToString();


            return outputCompilation;


        }
    }

}
