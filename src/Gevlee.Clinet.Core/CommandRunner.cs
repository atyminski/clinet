using System;
using System.Linq;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Flag;

namespace Gevlee.Clinet.Core
{
	public class CommandRunner
	{
		private readonly ICommandRegistry registry;

		public CommandRunner(ICommandRegistry registry)
		{
			this.registry = registry;
		}

		public string Header { get; set; }

		public void Run(string[] args)
		{
			DisplayHeader();
			var descriptionResult = ObjectFactory.ArgDescriberFactory(registry.Definitions).Describe(args);
			var commandContext = new CommandContext
			{
				Args = descriptionResult.CommandArgs
			};

			foreach (var descriptionResultFlagsValue in descriptionResult.FlagsValues)
			{
				var flag = descriptionResult.CommandDefinition.Flags.Single(x =>
					x.Key.NameEquals(descriptionResultFlagsValue.Key)).Value;

				flag.Apply(commandContext, new FlagData
				{
					Value = descriptionResultFlagsValue.Value
				});
			}

			var command = registry.GetCommand(descriptionResult.CommandDefinition);
			command.Run(commandContext);
		}

		private void DisplayHeader()
		{
			if (!string.IsNullOrEmpty(Header)) Console.WriteLine(Header + Environment.NewLine);
		}
	}
}