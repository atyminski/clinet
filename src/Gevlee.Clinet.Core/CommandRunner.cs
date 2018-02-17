using System;
using System.Collections.Generic;
using System.Linq;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core
{
    public class CommandRunner
    {
        private readonly ICommandRegistry registry;

        public CommandRunner(ICommandRegistry registry)
        {
            registry = registry;
        }

        public void Run(string[] args)
        {
            CommandDefinition mainCommandDefinition = null;
            CommandContext commandContext = new CommandContext();

            for (var i = 0; i < args.Length; i++)
            {
                if (IsFlag(args[i]))
                {
                    if (mainCommandDefinition == null)
                    {
                        //TODO: Show help...
                    }
                    else
                    {
                        var flagDefinition = FindFlags(mainCommandDefinition.Flags, args[i]);
                        if (flagDefinition == null)
                        {
                            throw new InvalidOperationException($"Invalid flag {args[i]}");
                        }

                        string flagValue = null;
                        var flag = mainCommandDefinition.Flags[flagDefinition];
                        if (flagDefinition.CanHasValue)
                        {
                            i++;
                            flagValue = args[i];
                        }
                        
                        flag.Apply(commandContext, new FlagData
                        {
                            Value = flagValue
                        });
                    }
                }
            }
        }

        private bool IsFlag(string s)
        {
            return s.StartsWith("-");
        }

        private FlagDefinition FindFlags(IDictionary<FlagDefinition, IFlag> flags, string s)
        {
            var flagName = ExtractFlagName(s);
            return flags.Keys.FirstOrDefault(x =>
                x.Short.Equals(flagName, StringComparison.OrdinalIgnoreCase) ||
                x.Long.Equals(flagName, StringComparison.OrdinalIgnoreCase));
        }

        private string ExtractFlagName(string s)
        {
            if (s.StartsWith("--"))
                return s.Substring(2);
            return s.Substring(1);
        }
    }
}