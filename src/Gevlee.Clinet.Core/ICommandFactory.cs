using System;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core
{
	public interface ICommandFactory
	{
		ICommand Create<TCommand>() where TCommand : ICommand;
		ICommand Create(Type type);
	}
}