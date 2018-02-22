using System.Collections.Generic;

namespace Gevlee.Clinet.Core.Command
{
	public interface IContextDataBinder
	{
		TData Bind<TData>(IDictionary<string, object> source, TData destination);
	}
}