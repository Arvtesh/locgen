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

		private const string _defaultResourceManagerClassName = "ResourceManager";
		private const string _defaultResourceManagerGetStringMethodName = "GetString";

		private string _resourceManagerClassName = _defaultResourceManagerClassName;
		private string _resourceManagerGetStringMethodName = _defaultResourceManagerGetStringMethodName;

		#endregion

		#region interface

		protected LocCodeGenerator(string name)
		{
			Name = name;
		}

		protected void WriteIdent(StreamWriter file, int identLevel, string s)
		{
			if (IdentSize > 0)
			{
				file.Write(new string(' ', identLevel * IdentSize));
			}
			else
			{
				file.Write(new string('\t', identLevel));
			}

			file.WriteLine(s);
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

		public int IdentSize { get; set; }

		public bool GenerateLocKeys { get; set; }

		public bool StaticAccess { get; set; }

		public string ResourceManagerClassRef
		{
			get
			{
				return _resourceManagerClassName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_resourceManagerClassName = _defaultResourceManagerClassName;
				}
				else
				{
					_resourceManagerClassName = value;
				}
			}
		}

		public string ResourceManagerGetStringMethod
		{
			get
			{
				return _resourceManagerGetStringMethodName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_resourceManagerGetStringMethodName = _defaultResourceManagerGetStringMethodName;
				}
				else
				{
					_resourceManagerGetStringMethodName = value;
				}
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
