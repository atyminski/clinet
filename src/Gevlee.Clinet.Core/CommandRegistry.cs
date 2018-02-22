using System;
using System.Collections.Generic;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core
{
	public class CommandRegistry : ICommandRegistry
	{
		private readonly ICommandFactory commandFactory;
		private readonly IDictionary<CommandDefinition, Type> commands;

		public CommandRegistry()
		{
			commands = new Dictionary<CommandDefinition, Type>();
			commandFactory = new SimpleCommandFactory();
		}

		public CommandRegistry(ICommandFactory commandFactory)
		{
			this.commandFactory = commandFactory;
		}

		public void Register<TCommand>(Action<ICommandDefinitionBuilder> definitionBuildAction) where TCommand : ICommand
		{
			var builder = new CommandDefinitionBuilder();
			definitionBuildAction(builder);
			Register<TCommand>(builder.Build());
		}

		public void Register<TCommand>(CommandDefinition definition) where TCommand : ICommand
		{
			commands.Add(definition, typeof(TCommand));
		}

		public ICommand GetCommand(CommandDefinition definition)
		{
			return commandFactory.Create(commands[definition]);
		}

		public IEnumerable<CommandDefinition> Definitions => commands.Keys;
	}
}