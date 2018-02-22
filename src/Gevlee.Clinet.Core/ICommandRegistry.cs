using System;
using System.Collections.Generic;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core
{
	public interface ICommandRegistry
	{
		IEnumerable<CommandDefinition> Definitions { get; }
		void Register<TCommand>(Action<ICommandDefinitionBuilder> definitionBuildAction) where TCommand : ICommand;
		void Register<TCommand>(CommandDefinition definition) where TCommand : ICommand;
		ICommand GetCommand(CommandDefinition definition);
	}
}