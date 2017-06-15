using System;
using System.Collections.Generic;
using System.Threading;

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

		protected LocCodeGenerator(string name)
		{
			Name = name;
		}

		#endregion

		#region ILocCodeGenerator

		public ILocCodeGeneratorSettings Settings => this;

		public string Name { get; }

		public abstract void Generate(ILocTree data, CancellationToken cancellationToken);

		#endregion

		#region ILocCodeGenerator

		public string TargetPath { get; set; }

		public string TargetNamespace { get; set; }

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
