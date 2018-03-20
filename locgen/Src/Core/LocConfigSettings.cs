using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	internal class LocConfigSettings
	{
		#region data

		private struct ArgData
		{
			public Action<LocConfig, string> Initializer { get; }
			public string Description { get; }

			public ArgData(Action<LocConfig, string> initializer, string desc)
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
			_args.Add("/SourceFilePath", new ArgData(OnSourceFilePath, "Path to the localization source file."));
			_args.Add("/SourceFileType", new ArgData(OnSourceFileType, "Type of the localization source. Supported values are Auto, Xliff12, Xliff20. Default is Auto."));
			_args.Add("/CodeGenType", new ArgData(OnCodeGenType, "Type of the code generator to use. Supported values are Csharp, Cpp. Default is Csharp."));
			_args.Add("/CodeGenTargetDir", new ArgData(OnCodeGenTargetDir, "Directory to store generated code files. Default is current directory."));
			_args.Add("/CodeGenNamespace", new ArgData(OnCodeGenNamespace, "Namespace to place the generated code to. Default is global namespace."));
			_args.Add("/CodeGenResourceManager", new ArgData(OnCodeGenResourceManager, "Name of a resource manager class to use. Default is ResourceManager."));
			_args.Add("/CodeGenStaticAccess", new ArgData(OnCodeGenStaticAccess, "Specified whether the generated classes should be static. Supported values are True, False. Default is False."));
			_args.Add("/ResGenType", new ArgData(OnResGenType, "Type of the resource generator to to use. Supported values are Resources, ResX, Json. Default is Resources."));
			_args.Add("/ResGenTargetDir", new ArgData(OnResGenTargetDir, "Directory to store generated resource files. Default is current directory."));
		}

		public void Parse(LocConfig config, string[] args)
		{
			config.CodeGenType = CodeGenType.CsharpUnity3d;
			config.ResGenType = ResGenType.Resources;

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
			Console.WriteLine("Usage:");
			Console.WriteLine("dotnet locgen /SourceFilePath:<source_file_path> [...]");
			Console.WriteLine();

			foreach (var item in _args)
			{
				Console.WriteLine("\t{0,-20}{1}", item.Key, item.Value.Description);
			}
		}

		#endregion

		#region implementation

		private void OnSourceFileType(LocConfig config, string value)
		{
			if (Enum.TryParse<LocTreeSourceType>(value, out var result))
			{
				config.SourceFileType = result;
			}
		}

		private void OnSourceFilePath(LocConfig config, string value)
		{
			config.SourceFilePath = value;
		}

		private void OnCodeGenType(LocConfig config, string value)
		{
			if (Enum.TryParse<CodeGenType>(value, out var result))
			{
				config.CodeGenType = result;
			}
		}

		private void OnCodeGenTargetDir(LocConfig config, string value)
		{
			config.CodeGenSettings.TargetDir = value;
		}

		private void OnCodeGenNamespace(LocConfig config, string value)
		{
			config.CodeGenSettings.TargetNamespace = value;
		}

		private void OnCodeGenResourceManager(LocConfig config, string value)
		{
			config.CodeGenSettings.ResourceManagerClass = value;
		}

		private void OnCodeGenStaticAccess(LocConfig config, string value)
		{
			config.CodeGenSettings.StaticAccess = (value == "True");
		}

		private void OnResGenType(LocConfig config, string value)
		{
			if (Enum.TryParse<ResGenType>(value, out var result))
			{
				config.ResGenType = result;
			}
		}

		private void OnResGenTargetDir(LocConfig config, string value)
		{
			config.ResGenSettings.TargetDir = value;
		}

		#endregion
	}
}
