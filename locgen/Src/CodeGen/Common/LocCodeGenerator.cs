using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A generic code generator.
	/// </summary>
	internal abstract class LocCodeGenerator : ILocCodeGenerator
	{
		#region data
		#endregion

		#region interface

		protected LocCodeGenerator(string name, ILocCodeGeneratorSettings settings)
		{
			Name = name;
			Settings = settings;
		}

		protected void WriteIdent(StreamWriter file, int identLevel, string s)
		{
			if (Settings.IdentSize > 0)
			{
				file.Write(new string(' ', identLevel * Settings.IdentSize));
			}
			else
			{
				file.Write(new string('\t', identLevel));
			}

			file.WriteLine(s);
		}

		protected abstract void GenerateInternal(ILocTree data, StreamWriter file, CancellationToken cancellationToken);
		protected abstract string GetTargetFileExtension();

		#endregion

		#region ILocCodeGenerator

		public ILocCodeGeneratorSettings Settings { get; }

		public string Name { get; }

		public void Generate(ILocTree data, CancellationToken cancellationToken)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			if (string.IsNullOrEmpty(Settings.TargetDir))
			{
				throw new ArgumentException("No target path specified");
			}

			cancellationToken.ThrowIfCancellationRequested();

			using (var file = File.CreateText(Path.Combine(Settings.TargetDir, data.Name + GetTargetFileExtension())))
			{
				GenerateInternal(data, file, cancellationToken);
			}
		}

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
