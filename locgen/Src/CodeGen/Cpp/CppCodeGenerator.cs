using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.CodeGen
{
	/// <summary>
	/// A C++ code generator.
	/// </summary>
	internal sealed class CppCodeGenerator : LocCodeGenerator
	{
		#region data
		#endregion

		#region interface

		public CppCodeGenerator()
			: base("Cpp")
		{
		}

		#endregion

		#region LocCodeGenerator

		protected override void GenerateInternal(ILocTree data, StreamWriter file, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region implementation
		#endregion
	}
}
