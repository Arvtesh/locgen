using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A C++ code generator.
	/// </summary>
	internal sealed class CppCodeGenerator : LocCodeGenerator
	{
		#region data
		#endregion

		#region interface

		public CppCodeGenerator(ILocCodeGeneratorSettings settings)
			: base(CodeGenType.Cpp.ToString(), settings)
		{
		}

		#endregion

		#region LocCodeGenerator

		protected override void GenerateInternal(ILocTree data, StreamWriter file, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		protected override string GetTargetFileExtension()
		{
			return ".generated.hpp";
		}

		#endregion

		#region implementation
		#endregion
	}
}
