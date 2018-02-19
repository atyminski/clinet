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
            var registry = new CommandRegistry();
            registry.Register<DemoCommand>(new CommandDefinition("run")
            {
                Description = "Invokes DemoCommand",
                Flags =
                {
                    {new FlagDefinition("b", "bl", true), Flags.Bool(nameof(DemoOptions.Bool))},
                    {new FlagDefinition("t", "date", true), Flags.DateTime(nameof(DemoOptions.Date))},
                }
            });

            var runner = new CommandRunner(registry)
            {
                Header =
                    $"{Assembly.GetExecutingAssembly().GetName().Name} {Assembly.GetExecutingAssembly().GetName().Version}"
            };
            runner.Run(args);
        }
    }
}
