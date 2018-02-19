using System;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Sample
{
    public class DemoCommand : ICommand
    {
        public void Run(CommandContext commandContext)
        {
            Console.WriteLine("DemoCommand invoked!");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Command data:");
            foreach (var data in commandContext.Data)
            {
                Console.WriteLine($"{data.Key}: {data.Value}");
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Command args:");
            foreach (var arg in commandContext.Args)
            {
                Console.WriteLine(arg);
            }
            
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Binded DemoOptions:");
            Console.WriteLine(commandContext.Bind<DemoOptions>());
        }
    }
}