using System;

namespace Gevlee.Clinet.Core.Common
{
	public abstract class BaseDefinition
	{
		protected BaseDefinition(string shortName, string longName)
		{
			Short = shortName;
			Long = longName;
		}

		public string Short { get; set; }

		public string Long { get; set; }

		public string Description { get; set; }

		public bool NameEquals(string name)
		{
			return (Short?.Equals(name, StringComparison.OrdinalIgnoreCase)).GetValueOrDefault() ||
			       (Long?.Equals(name, StringComparison.OrdinalIgnoreCase)).GetValueOrDefault();
		}
	}
}