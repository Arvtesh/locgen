using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocCodeGeneratorSettings
	{
		/// <summary>
		/// Gets or sets the path for the generated file (including file name and extension).
		/// </summary>
		string TargetPath { get; set; }

		/// <summary>
		/// Gets or sets name of the namespace for the generated file.
		/// </summary>
		string TargetNamespace { get; set; }

		/// <summary>
		/// Gets or sets format string that is used as a code returning a localized string for a given key.
		/// </summary>
		string GetMethodImpl { get; set; }
	}
}
