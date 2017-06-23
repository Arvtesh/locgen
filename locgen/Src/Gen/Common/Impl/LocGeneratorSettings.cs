using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocResGeneratorSettings"/>.
	/// </summary>
	internal abstract class LocGeneratorSettings : ILocGeneratorSettings
	{
		#region data

		private string _targetDir = Directory.GetCurrentDirectory();

		#endregion

		#region ILocResGeneratorSettings

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

		public int IdentSize { get; set; }

		#endregion
	}
}
