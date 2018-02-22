namespace Gevlee.Clinet.Core.Parsing
{
	public interface IArgsDescriber
	{
		ArgsDescriptionResult Describe(string[] args);
	}
}