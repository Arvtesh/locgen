using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocGeneratorSettings
	{
		/// <summary>
		/// Gets or sets the path for the generated file (including file name and extension).
		/// </summary>
		string TargetDir { get; set; }

		/// <summary>
		/// Gets or sets ident size (in spaces) for the generated file.
		/// </summary>
		int IdentSize { get; set; }
	}
}
