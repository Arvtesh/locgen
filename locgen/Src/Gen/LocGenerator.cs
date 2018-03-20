using System;
using System.IO;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// A generic resource file generator.
	/// </summary>
	internal abstract class LocGenerator : IDisposable
	{
		#region data

		private readonly string _name;
		private readonly LocGeneratorSettings _settings;

		#endregion

		#region interface

		protected LocGenerator(string name, LocGeneratorSettings settings)
		{
			_name = name;
			_settings = settings;
		}

		public void Generate(LocTree data, CancellationToken cancellationToken)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			cancellationToken.ThrowIfCancellationRequested();

			var targetPath = Path.Combine(_settings.TargetDir, data.Name + GetTargetFileExtension());
			GenerateInternal(data, targetPath, cancellationToken);
		}

		protected void WriteIdent(StreamWriter file, int identLevel, string s)
		{
			var identSize = _settings.IdentSize;

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

		protected abstract void GenerateInternal(LocTree data, string path, CancellationToken cancellationToken);
		protected abstract string GetTargetFileExtension();

		#endregion

		#region IDisposable

		public void Dispose()
		{
			// TODO
		}

		#endregion

		#region Object

		public override string ToString() => _name;

		#endregion

		#region implementation
		#endregion
	}
}
