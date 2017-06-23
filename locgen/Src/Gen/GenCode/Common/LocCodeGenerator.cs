using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A generic code generator.
	/// </summary>
	internal abstract class LocCodeGenerator : LocGenerator, ILocCodeGenerator
	{
		#region interface

		protected LocCodeGenerator(string name, ILocCodeGeneratorSettings settings)
			: base(name)
		{
			Settings = settings;
		}

		protected override ILocGeneratorSettings GetSettings() => Settings;

		#endregion

		#region ILocCodeGenerator

		public ILocCodeGeneratorSettings Settings { get; }

		#endregion
	}
}
