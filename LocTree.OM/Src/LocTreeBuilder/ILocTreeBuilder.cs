using System;
using System.Collections.Generic;
using System.IO;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeReader : IDisposable
	{
		/// <summary>
		/// Reads the <see cref="ILocTreeSet"/> instance from the specified stream.
		/// </summary>
		void Read(ILocTreeSet treeSet , Stream stream);
	}
}
