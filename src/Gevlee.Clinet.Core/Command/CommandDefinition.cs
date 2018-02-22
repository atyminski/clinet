using System.Collections.Generic;
using Gevlee.Clinet.Core.Common;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core.Command
{
	public class CommandDefinition : BaseDefinition
	{
		public CommandDefinition(string name) : this(null, name)
		{
		}

		public CommandDefinition(string shortName, string longName) : base(shortName, longName)
		{
			Flags = new Dictionary<FlagDefinition, IFlag>();
		}

		public CommandDefinition() : this(null, null)
		{
		}

		public IDictionary<FlagDefinition, IFlag> Flags { get; }
	}
}