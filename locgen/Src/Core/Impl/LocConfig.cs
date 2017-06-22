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

		private ILocCodeGeneratorSettings _settings1 = new LocCodeGeneratorSettings();
		private ILocResGeneratorSettings _settings2 = new LocResGeneratorSettings();

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
