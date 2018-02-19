using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Parsing;

[assembly: InternalsVisibleTo("Gevlee.Clinet.Core.Tests")]
namespace Gevlee.Clinet.Core
{
    internal static class ObjectFactory
    {
        public static Func<IEnumerable<CommandDefinition>, IArgsDescriber> ArgDescriberFactory { get; set; } =
            enumerable => new ArgsDescriber(enumerable);

        public static IContextDataBinder CreateDataBinder()
        {
            return new SimpleContextDataBinder();
        }
    }
}