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
		/// tt
		/// </summary>
		CodeGenType Type { get; }

		/// <summary>
		/// Returns the code generator settings. Read only.
		/// </summary>
		ILocCodeGeneratorSettings Settings { get; }
	}
}
