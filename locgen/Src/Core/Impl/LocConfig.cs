using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace locgen.Impl
{
	/// <summary>
	/// A generic config.
	/// </summary>
	internal class LocConfig : ILocConfig
	{
		#region data

		private ILocCodeGeneratorSettings _settings = new LocCodeGeneratorSettings();

		#endregion

		#region interface

		public SourceFileType SourceFileType { get; set; }

		public string SourceFilePath { get; set; }

		public CodeGenType CodeGenType { get; set; }

		public ILocCodeGeneratorSettings CodeGenSettings => _settings;

		#endregion
	}
}
