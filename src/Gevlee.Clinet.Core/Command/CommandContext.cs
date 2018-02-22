using System.Collections.Generic;

namespace Gevlee.Clinet.Core.Command
{
	public class CommandContext
	{
		public CommandContext()
		{
			Data = new Dictionary<string, object>();
			Args = new string[0];
			ShouldRun = true;
		}

		public IDictionary<string, object> Data { get; }

		public string[] Args { get; internal set; }

		public bool ShouldRun { get; set; }
	}
}