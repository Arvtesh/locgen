using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.CodeGen
{
	/// <summary>
	/// A generic code generator.
	/// </summary>
	internal abstract class LocCodeGenerator : ILocCodeGenerator, ILocCodeGeneratorSettings
	{
		#region data
		#endregion

		#region interface

		protected LocCodeGenerator(string name)
		{
			Name = name;
		}

		protected abstract void GenerateInternal(ILocTree data, StreamWriter file, CancellationToken cancellationToken);

		#endregion

		#region ILocCodeGenerator

		public ILocCodeGeneratorSettings Settings => this;

		public string Name { get; }

		public void Generate(ILocTree data, CancellationToken cancellationToken)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			if (string.IsNullOrEmpty(TargetPath))
			{
				throw new ArgumentException("No target path specified");
			}

			cancellationToken.ThrowIfCancellationRequested();

			using (var file = File.CreateText(TargetPath))
			{
				GenerateInternal(data, file, cancellationToken);
			}
		}

		#endregion

		#region ILocCodeGeneratorSettings

		public string TargetPath { get; set; }

		public string TargetNamespace { get; set; }

		public string GetMethodImpl { get; set; }

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
