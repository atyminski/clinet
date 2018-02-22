namespace Gevlee.Clinet.Core.Flag
{
	internal class FlagDefinitionBuilder : IFlagDefinitionBuilder
	{
		private readonly FlagDefinition definition;

		public FlagDefinitionBuilder()
		{
			definition = new FlagDefinition();
		}

		public IFlagDefinitionBuilder WithShortName(string name)
		{
			definition.Short = name;
			return this;
		}

		public IFlagDefinitionBuilder WithLongName(string name)
		{
			definition.Long = name;
			return this;
		}

		public IFlagDefinitionBuilder WithDescription(string description)
		{
			definition.Description = description;
			return this;
		}

		public FlagDefinition Build()
		{
			return definition;
		}
	}
}