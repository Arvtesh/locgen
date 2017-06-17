using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeGroup : ILocTreeItem
	{
		/// <summary>
		/// 
		/// </summary>
		IEnumerable<ILocTreeGroup> Groups { get; }

		/// <summary>
		/// 
		/// </summary>
		IEnumerable<ILocTreeUnit> Units { get; }

		/// <summary>
		/// 
		/// </summary>
		ILocTreeUnit AddUnit(string id, string name);

		/// <summary>
		/// 
		/// </summary>
		ILocTreeGroup AddGroup(string id, string name);
	}
}
