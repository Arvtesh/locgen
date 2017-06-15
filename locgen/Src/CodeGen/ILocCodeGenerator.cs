using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocCodeGenerator : IDisposable
	{
		/// <summary>
		/// Returns the code generator settings. Read only.
		/// </summary>
		ILocCodeGeneratorSettings Settings { get; }
	}
}
