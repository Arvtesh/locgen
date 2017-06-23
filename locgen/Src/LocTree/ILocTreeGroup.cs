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
		IEnumerable<ILocTreeUnit> UnitsRecursive { get; }

		/// <summary>
		/// 
		/// </summary>
		bool TryGetUnit(string id, out ILocTreeUnit unit);

		/// <summary>
		/// 
		/// </summary>
		bool TryGetGroup(string id, out ILocTreeGroup group);

		/// <summary>
		/// 
		/// </summary>
		ILocTreeText AddText(string id, string name);

		/// <summary>
		/// 
		/// </summary>
		ILocTreeTexture AddTexture(string id, string name);

		/// <summary>
		/// 
		/// </summary>
		ILocTreeAudio AddAudio(string id, string name);

		/// <summary>
		/// 
		/// </summary>
		ILocTreeGroup AddGroup(string id, string name);
	}
}
