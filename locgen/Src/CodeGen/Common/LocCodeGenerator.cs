using System;
using System.Collections.Generic;
using System.Text;

namespace locgen.CodeGen
{
	/// <summary>
	/// A generic code generator.
	/// </summary>
	public abstract class LocCodeGenerator : ILocCodeGenerator, ILocCodeGeneratorSettings
	{
		#region data
		#endregion

		#region interface
		#endregion

		#region ILocCodeGenerator

		public ILocCodeGeneratorSettings Settings => this;

		#endregion

		#region IDisposable

		public void Dispose()
		{
			// TODO
		}

		#endregion

		#region implementation
		#endregion
	}
}
