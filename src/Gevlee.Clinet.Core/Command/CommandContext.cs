using System.Collections.Generic;
using System.Dynamic;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core.Command
{
	public class CommandContext
	{
		public CommandContext()
		{
			Data = new ExpandoObject();
			ShouldRun = true;
		}

		public CommandDefinition CommandDefinition { get; internal set; }

		public dynamic Data { get; }

		public string[] Args { get; internal set; }

		public bool ShouldRun { get; set; }
	}
}