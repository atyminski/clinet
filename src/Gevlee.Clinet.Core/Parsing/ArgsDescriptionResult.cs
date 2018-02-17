using System.Collections.Generic;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core.Parsing
{
    public class ArgsDescriptionResult
    {
        public CommandDefinition CommandDefinition { get; set; }
        public string[] CommandArgs { get; set; }
        public Dictionary<string, string> FlagsValues { get; set; }

        public bool HasCommand => CommandDefinition != null;
    }
}