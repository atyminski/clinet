using System;

namespace Gevlee.Clinet.Core.Command
{
    public static class CommandContextExtensions
    {
        public static TData Bind<TData>(this CommandContext context)
        {
            return context.Bind(Activator.CreateInstance<TData>());
        }
        
        public static TData Bind<TData>(this CommandContext context, TData sourceObj)
        {
            return ObjectFactory.CreateDataBinder().Bind(context.Data, sourceObj);
        }
    }
}