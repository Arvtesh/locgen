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
		/// Reads the <see cref="ILocTree"/> instance from the specified stream.
		/// </summary>
		ILocTree[] Read(Stream stream);
	}
}
