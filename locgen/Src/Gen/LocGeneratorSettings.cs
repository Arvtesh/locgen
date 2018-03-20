using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	internal abstract class LocGeneratorSettings
	{
		#region data

		private string _targetDir = Directory.GetCurrentDirectory();

		#endregion

		#region interface

		/// <summary>
		/// Gets or sets the path for the generated file (including file name and extension).
		/// </summary>
		public string TargetDir
		{
			get
			{
				return _targetDir;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_targetDir = Directory.GetCurrentDirectory();
				}
				else
				{
					_targetDir = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets ident size (in spaces) for the generated file.
		/// </summary>
		public int IdentSize { get; set; }

		#endregion
	}
}
