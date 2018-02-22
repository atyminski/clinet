using System;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core
{
	internal class SimpleCommandFactory : ICommandFactory
	{
		public ICommand Create<TCommand>() where TCommand : ICommand
		{
			return Create(typeof(TCommand));
		}

		public ICommand Create(Type type)
		{
			return (ICommand) Activator.CreateInstance(type);
		}
	}
}