using System;
using System.Collections.Generic;
using System.Linq;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core.Parsing
{
    public class InvalidFlagException : Exception
    {
        public InvalidFlagException()
        {
        }

        public InvalidFlagException(string message) : base(message)
        {
        }

        public InvalidFlagException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class FlagValueNotFoundException : Exception
    {
        public FlagValueNotFoundException()
        {
        }

        public FlagValueNotFoundException(string message) : base(message)
        {
        }

        public FlagValueNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class ArgsDescriber : IArgsDescriber
    {
        private static readonly char[] FlagPrefixes = {
            '-'
        };

        public ArgsDescriber(IEnumerable<CommandDefinition> commandDefinitions)
        {
            CommandDefinitions = commandDefinitions;
        }
        
        public IEnumerable<CommandDefinition> CommandDefinitions { get; }
        
        public ArgsDescriptionResult Describe(string[] args)
        {
            var result = new ArgsDescriptionResult();
            var cmdArgs = new List<string>();

            for (var i = 0; i < args.Length; i++)
            {
                if (IsFlag(args[i]))
                {
                    var flagName = ExtractFlagName(args[i]);
                    if (result.HasCommand && TryFindFlag(flagName, result.CommandDefinition, out var flagDefinition))
                    {
                        if (flagDefinition.CanHasValue)
                        {
                            i++;
                            if (i >= args.Length)
                            {
                                throw new FlagValueNotFoundException(flagName);
                            }
                            result.FlagsValues.Add(flagName, args[i]);
                        }
                        else
                        {
                            result.FlagsValues.Add(flagName, null);
                        }
                    }
                    else
                    {
                        throw new InvalidFlagException(flagName);
                    }
                }
                else
                {
                    var candidate = args[i];
                    if (!result.HasCommand && TryFindCommand(candidate, out var commandDefinition))
                    {
                        result.CommandDefinition = commandDefinition;
                    }
                    else
                    {
                        cmdArgs.Add(args[i]);
                    }
                }
            }

            result.CommandArgs = cmdArgs.ToArray();
            return result;
        }

        private bool TryFindFlag(string candidate, CommandDefinition commandDefinition,
            out FlagDefinition flagDefinition)
        {
            flagDefinition = commandDefinition.Flags.FirstOrDefault(x => x.Key.NameEquals(candidate)).Key;
            return flagDefinition != null;
        }

        private bool TryFindCommand(string candidate, out CommandDefinition commandDefinition)
        {
            commandDefinition = CommandDefinitions.FirstOrDefault(x => x.NameEquals(candidate));
            return commandDefinition != null;
        }

        private bool IsFlag(string candidate)
        {
            return FlagPrefixes.Any(x => candidate.StartsWith(x.ToString()));
        }

        private string ExtractFlagName(string fromArgs)
        {
            return fromArgs.TrimStart(FlagPrefixes);
        }
    }
}