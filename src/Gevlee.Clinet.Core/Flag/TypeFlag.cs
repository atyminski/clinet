using System;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core.Flag
{
    public class TypeFlag : IFlag
    {
        private readonly string key;

        public TypeFlag(string key)
        {
            this.key = key;
        }
        
        public Func<string, object> ConvertFunc { get; set; }
        
        public void Apply(CommandContext commandContext, FlagData data)
        {
            try
            {
                commandContext.Data[key] = ConvertFunc(data.Value);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Error when converting value: {data.Value}", e);
            }
        }
    }
}