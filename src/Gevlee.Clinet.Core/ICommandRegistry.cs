using System;
using System.Collections.Generic;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core
{
    public interface ICommandRegistry
    {
        void Register<TCommand>(Action<ICommandDefinitionBuilder> definitionBuildAction) where TCommand : ICommand;
        void Register<TCommand>(CommandDefinition definition) where TCommand : ICommand;
        ICommand GetCommand(CommandDefinition definition);
        IEnumerable<CommandDefinition> Definitions { get; }
    }
}