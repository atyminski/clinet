namespace Gevlee.Clinet.Core.Flag
{
	public class FlagData
	{
		public string FlagName { get; set; }

		public string Value { get; set; }

		public bool HasValue => !string.IsNullOrEmpty(Value);
	}
}