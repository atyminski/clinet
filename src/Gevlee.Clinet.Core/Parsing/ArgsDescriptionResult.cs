using System.Collections.Generic;
using Gevlee.Clinet.Core.Command;

namespace Gevlee.Clinet.Core.Parsing
{
    public class ArgsDescriptionResult
    {
        public ArgsDescriptionResult()
        {
            FlagsValues = new Dictionary<string, string>();
        }

        public CommandDefinition CommandDefinition { get; set; }
        public string[] CommandArgs { get; set; }
        public Dictionary<string, string> FlagsValues { get; }

        public bool HasCommand => CommandDefinition != null;
    }
}