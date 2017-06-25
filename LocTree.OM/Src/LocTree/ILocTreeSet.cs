using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeSet : IEnumerable<ILocTree>
	{
		/// <summary>
		/// 
		/// </summary>
		ILocTree Add(string id, string name);
	}
}
