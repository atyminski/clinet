using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core.Flag
{
	public interface IFlag
	{
		void Apply(CommandContext commandContext, FlagData data);
	}
}