using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// A generic resource generator.
	/// </summary>
	internal abstract class LocResGenerator : LocGenerator
	{
		#region interface

		protected LocResGenerator(string name, LocResGeneratorSettings settings)
			: base(name, settings)
		{
			Settings = settings;
		}

		public LocResGeneratorSettings Settings { get; }

		#endregion
	}
}
