using System.Collections.Generic;
using System.Dynamic;

namespace Gevlee.Clinet.Core.Command
{
	public class CommandContext
	{
		public CommandContext()
		{
			Data = new Dictionary<string, object>();
			ShouldRun = true;
		}

		public CommandDefinition CommandDefinition { get; internal set; }

		public IDictionary<string, object> Data { get; }

	    public string[] Args { get; internal set; }

		public bool ShouldRun { get; set; }
	}
}