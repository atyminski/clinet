using Gevlee.Clinet.Core.Common;

namespace Gevlee.Clinet.Core.Flag
{
	public class FlagDefinition : BaseDefinition
	{
		public FlagDefinition(string shortName, string longName, bool canHasValue) : base(shortName, longName)
		{
			CanHasValue = canHasValue;
		}

		public FlagDefinition(string shortName, string longName) : base(shortName, longName)
		{
		}

		public FlagDefinition() : this(null, null)
		{
		}

		public bool CanHasValue { get; set; }
	}
}