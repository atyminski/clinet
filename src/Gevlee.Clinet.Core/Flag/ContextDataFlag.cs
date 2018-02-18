using System.Collections.Generic;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core.Flag
{
	public class ContextDataFlag : IFlag
	{
		private readonly string key;

		public ContextDataFlag(string key)
		{
			this.key = key;
		}

		public void Apply(CommandContext commandContext, FlagData data)
		{
			commandContext.Data.Add(key, data.Value);
		}
	}
}