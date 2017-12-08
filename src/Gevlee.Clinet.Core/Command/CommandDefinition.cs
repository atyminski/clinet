using Gevlee.Clinet.Core.Common;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core.Command
{
	public class CommandDefinition : BaseDefinition
	{
		public FlagDefinition[] Flags { get; set; }
	}
}