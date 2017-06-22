using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A generic resource generator.
	/// </summary>
	internal abstract class LocResGenerator : LocGenerator, ILocResGenerator
	{
		#region interface

		protected LocResGenerator(string name, ILocResGeneratorSettings settings)
			: base(name)
		{
			Settings = settings;
		}

		protected override ILocGeneratorSettings GetSettings() => Settings;

		#endregion

		#region ILocCodeGenerator

		public ILocResGeneratorSettings Settings { get; }

		#endregion
	}
}
