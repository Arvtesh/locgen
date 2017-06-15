using System;
using System.Collections.Generic;
using System.Threading;

namespace locgen.CodeGen
{
	/// <summary>
	/// A C++ code generator.
	/// </summary>
	public sealed class CppCodeGenerator : LocCodeGenerator
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

		public override void Generate(ILocTree data, CancellationToken cancellationToken)
		{
			// TODO
		}

		#endregion

		#region implementation
		#endregion
	}
}
