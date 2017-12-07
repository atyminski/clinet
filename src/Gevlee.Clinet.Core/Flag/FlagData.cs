namespace Gevlee.Clinet.Core.Flag
{
	public class FlagData
	{
		public string Value { get; set; }

		public bool HasValue => !string.IsNullOrEmpty(Value);
	}
}