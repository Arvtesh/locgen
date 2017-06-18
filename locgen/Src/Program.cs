using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace locgen
{
	class Program
	{
		static void Main(string[] args)
		{
			var assembly = Assembly.GetEntryAssembly();
			var assemblyName = Assembly.GetEntryAssembly().GetName();

			Console.WriteLine(assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description);
			Console.WriteLine("v" + assemblyName.Version);
			Console.WriteLine();

			var config = FromArgs(args);

			if (config != null)
			{
				var ct = new CancellationTokenSource();

				foreach (var tree in LoadLocTrees(config))
				{
					if (config.CodeGenType != CodeGenType.None)
					{
						using (var cg = CreateCodeGenerator(config.CodeGenType, config.CodeGenSettings))
						{
							cg.Generate(tree, ct.Token);
						}
					}
				}
			}
		}

		static ILocConfig FromArgs(string[] args)
		{
			var result = new Impl.LocConfig();
			var settings = new Impl.LocConfigSettings();
			settings.Parse(result, args);

			if (string.IsNullOrEmpty(result.SourceFilePath))
			{
				settings.WriteHelp();
				return null;
			}

			return result;
		}

		static ILocTree[] LoadLocTrees(ILocConfig config)
		{
			using (var stream = new FileStream(config.SourceFilePath, FileMode.Open, FileAccess.Read))
			{
				var fileType = config.SourceFileType;

				if (fileType == SourceFileType.Auto)
				{
					if (config.SourceFilePath.EndsWith(".xml"))
					{
						fileType = SourceFileType.Xml;
					}
					else if (config.SourceFilePath.EndsWith(".json"))
					{
						fileType = SourceFileType.Json;
					}
					else
					{
						fileType = SourceFileType.Xliff20;
					}
				}

				using (var treeBuilder = CreateTreeBuilder(fileType))
				{
					return treeBuilder.Read(stream);
				}
			}
		}

		static ILocTreeBuilder CreateTreeBuilder(SourceFileType fileType)
		{
			switch (fileType)
			{
				case SourceFileType.Xliff20:
					return new Impl.XliffTreeBuilder();

				default:
					throw new NotImplementedException();
			}
		}

		static ILocCodeGenerator CreateCodeGenerator(CodeGenType codeGenType, ILocCodeGeneratorSettings settings)
		{
			switch (codeGenType)
			{
				case CodeGenType.Csharp:
					return new Impl.CsharpCodeGenerator(settings);

				case CodeGenType.Cpp:
					return new Impl.CppCodeGenerator(settings);

				default:
					return new Impl.CsharpCodeGenerator(settings);
			}
		}
	}
}
