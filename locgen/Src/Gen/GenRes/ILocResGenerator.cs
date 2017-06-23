using System;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocResGenerator : ILocGenerator
	{
		/// <summary>
		/// Returns the generator settings. Read only.
		/// </summary>
		ILocResGeneratorSettings Settings { get; }
	}
}
