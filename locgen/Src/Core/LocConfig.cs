using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace locgen
{
	/// <summary>
	/// A generic config.
	/// </summary>
	internal class LocConfig
	{
		#region data

		private ILocCodeGeneratorSettings _settings1 = new Impl.LocCodeGeneratorSettings();
		private ILocResGeneratorSettings _settings2 = new Impl.LocResGeneratorSettings();

		#endregion

		#region interface

		public SourceFileType SourceFileType { get; set; }

		public string SourceFilePath { get; set; }

		public CodeGenType CodeGenType { get; set; }

		public ILocCodeGeneratorSettings CodeGenSettings => _settings1;

		public ResGenType ResGenType { get; set; }

		public ILocResGeneratorSettings ResGenSettings => _settings2;

		#endregion
	}
}
