using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Flag;
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

        [Fact]
        public void Describe_ShoultReturn_DescriptionResultWithCommandAndMultipleCommandArgs()
        {
            var args = new[] { "cmd", "cmdarg1", "cmdarg2" };
            var commandDefinitions = new[]
            {
                new CommandDefinition("c", "cmd")
            };

            var result = CreateObject(commandDefinitions).Describe(args);

            result.CommandDefinition.ShouldBeEquivalentTo(commandDefinitions[0]);
            result.CommandArgs.ShouldBeEquivalentTo(args.Skip(1).ToArray());
        }

        [Fact]
        public void Describe_ShoultReturn_DescriptionResultWithCommandAndOneNonValueFlag()
        {
            var args = new[] { "testCommand", "-f"};
            var commandDefinitions = new[]
            {
                new CommandDefinition("t1", "TestCommand")
                {
                    Flags = { {new FlagDefinition("f", null)
                    {
                    }, null}}
                }
            };

            var result = CreateObject(commandDefinitions).Describe(args);

            result.CommandDefinition.ShouldBeEquivalentTo(commandDefinitions[0]);
            result.FlagsValues["f"].ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Describe_ShoultReturn_DescriptionResultWithCommandAndOneValueFlag()
        {
            var args = new[] { "testCommand", "-f", "f1Value" };
            var commandDefinitions = new[]
            {
                new CommandDefinition("t1", "TestCommand")
                {
                    Flags = { {new FlagDefinition("f", null)
                    {
                        CanHasValue = true
                    }, null}}
                }
            };

            var result = CreateObject(commandDefinitions).Describe(args);

            result.CommandDefinition.ShouldBeEquivalentTo(commandDefinitions[0]);
            result.FlagsValues["f"].ShouldBeEquivalentTo("f1Value");
        }

        [Fact]
        public void Describe_ShoultThrow_FlagValueNotFoundException()
        {
            var args = new[] { "testCommand", "-f" };
            var commandDefinitions = new[]
            {
                new CommandDefinition("t1", "TestCommand")
                {
                    Flags = { {new FlagDefinition("f", null)
                    {
                        CanHasValue = true
                    }, null}}
                }
            };

            Assert.Throws<FlagValueNotFoundException>(() => CreateObject(commandDefinitions).Describe(args));
        }

        [Fact]
        public void Describe_ShoultReturn_DescriptionResultWithCommandAndOneValueFlagAndOneNonValueFlag()
        {
            var args = new[] { "testCommand", "-q", "-f", "f1Value" };
            var commandDefinitions = new[]
            {
                new CommandDefinition("t1", "TestCommand")
                {
                    Flags =
                    {
                        {
                            new FlagDefinition("f", null)
                            {
                                CanHasValue = true
                            },
                            null
                        },
                        {
                            new FlagDefinition("q", null)
                            {
                                CanHasValue = false
                            },
                            null
                        }
                    }
                }
            };

            var result = CreateObject(commandDefinitions).Describe(args);

            result.CommandDefinition.ShouldBeEquivalentTo(commandDefinitions[0]);
            result.FlagsValues["f"].ShouldBeEquivalentTo("f1Value");
            result.FlagsValues["q"].ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Describe_ShoultReturn_DescriptionResultWithCommandAndOneValueFlagAndOneNonValueFlagAndCommandArgs()
        {
            var args = new[] { "testCommand", "-q", "-f", "f1Value", "commandValue"};
            var commandDefinitions = new[]
            {
                new CommandDefinition("t1", "TestCommand")
                {
                    Flags =
                    {
                        {
                            new FlagDefinition("f", null)
                            {
                                CanHasValue = true
                            },
                            null
                        },
                        {
                            new FlagDefinition("q", null)
                            {
                                CanHasValue = false
                            },
                            null
                        }
                    }
                }
            };

            var result = CreateObject(commandDefinitions).Describe(args);

            result.CommandDefinition.ShouldBeEquivalentTo(commandDefinitions[0]);
            result.FlagsValues["f"].ShouldBeEquivalentTo("f1Value");
            result.FlagsValues["q"].ShouldBeEquivalentTo(null);
            result.CommandArgs.ShouldBeEquivalentTo(args.Skip(4).ToArray());
        }

        private ArgsDescriber CreateObject(IEnumerable<CommandDefinition> commandDefinitions)
        {
            return new ArgsDescriber(commandDefinitions);
        }
    }
}