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

		private LocCodeGeneratorSettings _settings1 = new LocCodeGeneratorSettings();
		private LocResGeneratorSettings _settings2 = new LocResGeneratorSettings();

		#endregion

		#region interface

		public LocTreeSourceType SourceFileType { get; set; }

		public string SourceFilePath { get; set; }

		public CodeGenType CodeGenType { get; set; }

		public LocCodeGeneratorSettings CodeGenSettings => _settings1;

		public ResGenType ResGenType { get; set; }

		public LocResGeneratorSettings ResGenSettings => _settings2;

		#endregion
	}
}
