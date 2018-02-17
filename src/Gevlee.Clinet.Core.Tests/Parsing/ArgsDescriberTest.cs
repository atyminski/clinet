using System.Collections.Generic;
using FluentAssertions;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Parsing;
using Xunit;

namespace Gevlee.Clinet.Core.Tests.Parsing
{
    public class ArgsDescriberTest
    {
        [Fact]
        public void Describe_ShoultReturn_DescriptionResultWithLongCommandName()
        {
            var args = new [] {"testCommand"};
            var commandDefinitions = new[]
            {
                new CommandDefinition("t", args[0])
            };

            var result = CreateObject(commandDefinitions).Describe(args);

            result.CommandDefinition.ShouldBeEquivalentTo(commandDefinitions[0]);
        }
        
        [Fact]
        public void Describe_ShoultReturn_DescriptionResultWithOnlyCommandArgs()
        {
            var args = new [] {"testCommand"};
            var commandDefinitions = new[]
            {
                new CommandDefinition("t1", "not-in-args")
            };

            var result = CreateObject(commandDefinitions).Describe(args);

            result.CommandDefinition.ShouldBeEquivalentTo(null);
            result.CommandArgs.ShouldBeEquivalentTo(args);
        }

        private ArgsDescriber CreateObject(IEnumerable<CommandDefinition> commandDefinitions)
        {
            return new ArgsDescriber(commandDefinitions);
        }
    }
}