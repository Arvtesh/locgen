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
	}
}
