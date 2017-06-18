using System;
using System.Collections.Generic;
using System.Text;

namespace locgen.Impl
{
	/// <summary>
	/// 
	/// </summary>
	internal class LocConfigSettings
	{
		#region data

		private struct ArgData
		{
			public Action<ILocConfig, string> Initializer { get; }
			public string Description { get; }

			public ArgData(Action<ILocConfig, string> initializer, string desc)
			{
				Initializer = initializer;
				Description = desc;
			}
		}

		private Dictionary<string, ArgData> _args = new Dictionary<string, ArgData>();

		#endregion

		#region interface

		public LocConfigSettings()
		{
			_args.Add("/SourceFileType", new ArgData(OnSourceFileType, "Type of the localization source. Supported values are Auto, Xliff12, Xliff20. Default is Auto."));
			_args.Add("/SourceFilePath", new ArgData(OnSourceFilePath, "Path to the localization source file."));
			_args.Add("/CodeGenType", new ArgData(OnCodeGenType, "Type of the code generator to use. Supported values are Csharp, Cpp. Default is Csharp."));
			_args.Add("/CodeGenTargetDir", new ArgData(OnCodeGenTargetDir, "Directory to store generated code files. Default is current directory."));
			_args.Add("/CodeGenNamespace", new ArgData(OnCodeGenNamespace, "Namespace to place the generated code to."));
		}

		public void Parse(ILocConfig config, string[] args)
		{
			foreach (var arg in args)
			{
				var key = arg;
				var value = string.Empty;
				var separatorIndex = arg.IndexOf(':');

				if (separatorIndex > 0)
				{
					key = arg.Substring(0, separatorIndex);
					value = arg.Substring(separatorIndex + 1);
				}

				if (_args.TryGetValue(key, out var argData))
				{
					argData.Initializer(config, value);
				}
			}
		}

		public void WriteHelp()
		{
			foreach (var item in _args)
			{
				Console.WriteLine("\t{0,-20}{1}", item.Key, item.Value.Description);
			}
		}

		#endregion

		#region implementation

		private void OnSourceFileType(ILocConfig config, string value)
		{
			if (Enum.TryParse<SourceFileType>(value, out var result))
			{
				config.SourceFileType = result;
			}
		}

		private void OnSourceFilePath(ILocConfig config, string value)
		{
			config.SourceFilePath = value;
		}

		private void OnCodeGenType(ILocConfig config, string value)
		{
			if (Enum.TryParse<CodeGenType>(value, out var result))
			{
				config.CodeGenType = result;
			}
		}

		private void OnCodeGenTargetDir(ILocConfig config, string value)
		{
			config.CodeGenSettings.TargetDir = value;
		}

		private void OnCodeGenNamespace(ILocConfig config, string value)
		{
			config.CodeGenSettings.TargetNamespace = value;
		}

		#endregion
	}
}
