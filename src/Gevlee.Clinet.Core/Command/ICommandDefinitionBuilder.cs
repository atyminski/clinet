﻿using System;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core.Command
{
    public interface ICommandDefinitionBuilder
    {
        ICommandDefinitionBuilder WithShortName(string name);
        
        ICommandDefinitionBuilder WithLongName(string name);
        
        ICommandDefinitionBuilder WithDescription(string description);

        ICommandDefinitionBuilder WithFlag<TFlag>(Action<IFlagDefinitionBuilder> flagDefinitionBuildFunction)
            where TFlag : IFlag;

        ICommandDefinitionBuilder WithFlag<TFlag>(FlagDefinition definition) where TFlag : IFlag;
        CommandDefinition Build();
    }
}