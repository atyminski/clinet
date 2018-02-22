using System.Collections.Generic;
using FluentAssertions;
using Gevlee.Clinet.Core.Command;
using Xunit;

namespace Gevlee.Clinet.Core.Tests.Command
{
	public class SimpleCommandDataBinderTest
	{
		private SimpleContextDataBinder CreateObject()
		{
			return new SimpleContextDataBinder();
		}

		private class TestData
		{
			public string TestString { get; set; }
			public int TestInt { get; set; }
			public int TestNotWritable { get; }
		}

		[Fact]
		public void Bind_ShouldMap_AllPropertiesWritableProperties()
		{
			var data = new Dictionary<string, object>
			{
				{nameof(TestData.TestString), "TestStringValue"},
				{nameof(TestData.TestInt), 999}
			};

			var result = new TestData();

			CreateObject().Bind(data, result);

			result.TestInt.ShouldBeEquivalentTo(999);
			result.TestString.ShouldBeEquivalentTo("TestStringValue");
		}

		[Fact]
		public void Bind_ShouldNotCrash_WhenDictionaryContainsNotPropertyNameKey()
		{
			var data = new Dictionary<string, object>
			{
				{"NotPropertyNameKey", 999}
			};

			var result = new TestData();

			CreateObject().Bind(data, result);
		}

		[Fact]
		public void Bind_ShouldNotMap_NotWritableProperty()
		{
			var data = new Dictionary<string, object>
			{
				{nameof(TestData.TestNotWritable), 999}
			};

			var result = new TestData();

			CreateObject().Bind(data, result);

			result.TestNotWritable.ShouldBeEquivalentTo(default(int));
		}
	}
}