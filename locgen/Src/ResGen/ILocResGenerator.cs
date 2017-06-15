using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocResGenerator : IDisposable
	{
		/// <summary>
		/// Returns the generator name. Read only.
		/// </summary>
		string Name { get; }
	}
}
