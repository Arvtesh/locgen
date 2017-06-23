using System;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A generic resource file generator.
	/// </summary>
	internal abstract class LocGenerator : ILocGenerator
	{
		#region data
		#endregion

		#region interface

		protected LocGenerator(string name)
		{
			Name = name;
		}

		protected void WriteIdent(StreamWriter file, int identLevel, string s)
		{
			var identSize = GetSettings().IdentSize;

			if (identSize > 0)
			{
				file.Write(new string(' ', identLevel * identSize));
			}
			else
			{
				file.Write(new string('\t', identLevel));
			}

			file.WriteLine(s);
		}

		protected abstract void GenerateInternal(ILocTree data, StreamWriter file, CancellationToken cancellationToken);
		protected abstract string GetTargetFileExtension();
		protected abstract ILocGeneratorSettings GetSettings();

		#endregion

		#region IResCodeGenerator

		public string Name { get; }

		public void Generate(ILocTree data, CancellationToken cancellationToken)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			cancellationToken.ThrowIfCancellationRequested();

			using (var file = File.CreateText(Path.Combine(GetSettings().TargetDir, data.Name + GetTargetFileExtension())))
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
