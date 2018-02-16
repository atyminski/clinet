using System.Collections.Generic;
using Gevlee.Clinet.Core.Common;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core.Command
{
	public class CommandDefinition : BaseDefinition
	{
		public CommandDefinition()
		{
			Flags = new Dictionary<FlagDefinition, IFlag>();
		}

		public IDictionary<FlagDefinition, IFlag> Flags { get; }
	}
}