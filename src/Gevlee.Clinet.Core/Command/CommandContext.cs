using System.Collections.Generic;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core.Command
{
	public class CommandContext
	{
		public CommandContext()
		{
			Data = new Dictionary<string, string>();
			ShouldRun = true;
		}

		public CommandDefinition CommandDefinition { get; internal set; }

		public IDictionary<string, string> Data { get; }

		public string[] Args { get; internal set; }

		public bool ShouldRun { get; set; }

		public FlagDefinition[] Flags { get; set; }
	}
}