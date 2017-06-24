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

		protected LocCodeGenerator(CodeGenType type, ILocCodeGeneratorSettings settings)
			: base(type.ToString())
		{
			Type = type;
			Settings = settings;
		}

		protected override ILocGeneratorSettings GetSettings() => Settings;

		#endregion

		#region ILocCodeGenerator

		public CodeGenType Type { get; }

		public ILocCodeGeneratorSettings Settings { get; }

		#endregion
	}
}
