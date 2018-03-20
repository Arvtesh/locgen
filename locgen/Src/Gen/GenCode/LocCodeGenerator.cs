using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// A generic code generator.
	/// </summary>
	internal abstract class LocCodeGenerator : LocGenerator
	{
		#region interface

		/// <summary>
		/// 
		/// </summary>
		public CodeGenType Type { get; }

		/// <summary>
		/// Returns the code generator settings. Read only.
		/// </summary>
		public LocCodeGeneratorSettings Settings { get; }

		protected LocCodeGenerator(CodeGenType type, LocCodeGeneratorSettings settings)
			: base(type.ToString(), settings)
		{
			Type = type;
			Settings = settings;
		}

		#endregion
	}
}
