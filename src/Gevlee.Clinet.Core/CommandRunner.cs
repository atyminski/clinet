using System.Linq;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Flag;
using Gevlee.Clinet.Core.Parsing;

namespace Gevlee.Clinet.Core
{
    public class CommandRunner
    {
        private readonly ICommandRegistry registry;

        public CommandRunner(ICommandRegistry registry)
        {
            this.registry = registry;
        }

        public void Run(string[] args)
        {
            var descriptionResult = new ArgsDescriber(registry.Definitions).Describe(args);
            var commandContext = new CommandContext
            {
                Args = descriptionResult.CommandArgs,
                CommandDefinition = descriptionResult.CommandDefinition
            };

            foreach (var descriptionResultFlagsValue in descriptionResult.FlagsValues)
            {
                var flag = descriptionResult.CommandDefinition.Flags.Single(x =>
                    x.Key.NameEquals(descriptionResultFlagsValue.Key)).Value;

                flag.Apply(commandContext, new FlagData
                {
                    Value = descriptionResultFlagsValue.Key
                });
            }

            var command = registry.GetCommand(descriptionResult.CommandDefinition);
            command.Run(commandContext);
        }
    }
}