using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var result = BuildManager.DefaultBuildManager.Build(
                    new BuildParameters
                    {
                        Loggers = new[] { new ConsoleLogger() }
                    },
                    new BuildRequestData(
                        new ProjectInstance(@"..\..\..\TheProject\TheProject.csproj"), new[] {"Rebuild"}));
                Console.WriteLine("OveralResult: {0}", result.OverallResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed with exception: {0}", e);
            }
        }
    }
}
