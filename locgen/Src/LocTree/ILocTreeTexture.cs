using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILocTreeTexture : ILocTreeUnit
	{
		/// <summary>
		/// Returns texture path using neutral culture. Read only.
		/// </summary>
		string SrcPath { get; set; }

		/// <summary>
		/// Returns localized texture path (using the target culture). Read only.
		/// </summary>
		string TargetPath { get; set; }
	}
}
