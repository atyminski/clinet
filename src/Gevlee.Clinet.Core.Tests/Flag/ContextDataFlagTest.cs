using AutoFixture.Xunit2;
using FluentAssertions;
using Gevlee.Clinet.Core.Command;
using Gevlee.Clinet.Core.Flag;
using Xunit;

namespace Gevlee.Clinet.Core.Tests.Flag
{
	public class ContextDataFlagTest
	{
		[Theory, AutoData]
		public void Apply_ShouldSet_DataToContext(string value)
		{
			var flag = GetObject("Test");
			var context = new CommandContext();
			flag.Apply(context, new FlagData
			{
				Value = value
			});

			((string)context.Data.Test).ShouldBeEquivalentTo(value);
		}

		private ContextDataFlag GetObject(string key)
		{
			return new ContextDataFlag(key);
		}
	}
}