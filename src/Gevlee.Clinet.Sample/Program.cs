using System;
using System.Diagnostics;
using System.Reflection;
using Gevlee.Clinet.Core;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Debugger.Launch();
            var registry = new CommandRegistry();
            registry.Register<DemoCommand>(new CommandDefinition("run")
            {
                Description = "Invokes DemoCommand",
                Flags = { {new FlagDefinition("d", "demo-flag", true), new ContextDataFlag("demo-flag-data")}}
            });

            var runner = new CommandRunner(registry);
            runner.Header = $"{Assembly.GetExecutingAssembly().GetName().Name} {Assembly.GetExecutingAssembly().GetName().Version}";
            runner.Run(args);
        }
    }
}
