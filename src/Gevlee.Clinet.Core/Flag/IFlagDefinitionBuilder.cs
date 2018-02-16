namespace Gevlee.Clinet.Core.Flag
{
    public interface IFlagDefinitionBuilder
    {
        IFlagDefinitionBuilder WithShortName(string name);
        IFlagDefinitionBuilder WithLongName(string name);
        IFlagDefinitionBuilder WithDescription(string description);
        FlagDefinition Build();
    }
}