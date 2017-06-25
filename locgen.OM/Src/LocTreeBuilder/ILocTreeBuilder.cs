using System;
using System.Collections.Generic;
using System.IO;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeBuilder : IDisposable
	{
		/// <summary>
		/// Returns the generator name. Read only.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Reads the <see cref="ILocTreeSet"/> instance from the specified stream.
		/// </summary>
		void Read(ILocTreeSet treeSet , Stream stream);
	}
}
