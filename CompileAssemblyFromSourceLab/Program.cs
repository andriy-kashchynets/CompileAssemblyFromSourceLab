using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CSharp;

namespace CompileAssemblyFromSourceLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = "Class1.cs";

            if (args.Length > 0)
            {
                sourceFileName = args[0];
            }

            var sourceFile = File.ReadAllText(sourceFileName);


            var options = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };
            var csc = new CSharpCodeProvider(options);

            var parameters = new CompilerParameters();

            //parameters.GenerateInMemory = true;

            //parameters.GenerateExecutable = false;

            //parameters.ReferencedAssemblies.Add("System.dll");
            //parameters.ReferencedAssemblies.Add("System.Core.dll");
            //parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");

            //parameters.ReferencedAssemblies.Add("System.IO.dll");
            //parameters.ReferencedAssemblies.Add("System.Net.Http.dll");
            //parameters.ReferencedAssemblies.Add("System.Runtime.dll");
            //parameters.ReferencedAssemblies.Add("System.Threading.Tasks.dll");
            
            //parameters.ReferencedAssemblies.Add("Microsoft.Threading.Tasks.dll");
            //parameters.ReferencedAssemblies.Add("Microsoft.Threading.Tasks.Extensions.dll");
            //parameters.ReferencedAssemblies.Add("Microsoft.Threading.Tasks.Extensions.Desktop.dll");

            //parameters.CompilerOptions = "/target:library";
        
            var results = csc.CompileAssemblyFromSource(parameters, sourceFile);

            if (results.Errors.Count > 0)
            {
                // Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}",
                    sourceFile, results.PathToAssembly);
                foreach (CompilerError ce in results.Errors)
                {
                    Console.WriteLine("  {0}", ce);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    sourceFile, results.PathToAssembly);
                Console.WriteLine("{0} temporary files created during the compilation.",
                    results.TempFiles.Count.ToString());

            }
        }
    }
}
