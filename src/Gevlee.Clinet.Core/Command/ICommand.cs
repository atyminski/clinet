namespace Gevlee.Clinet.Core.Command
{
	public interface ICommand
	{
		void Run(CommandContext commandContext);
	}
}