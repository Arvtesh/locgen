using System;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocCodeGenerator : ILocGenerator
	{
		/// <summary>
		/// Returns the code generator settings. Read only.
		/// </summary>
		ILocCodeGeneratorSettings Settings { get; }
	}
}
