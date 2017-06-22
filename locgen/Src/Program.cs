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

				foreach (var tree in LoadLocTrees(config.SourceFilePath, config.SourceFileType))
				{
					if (config.CodeGenType != CodeGenType.None)
					{
						using (var cg = CreateCodeGenerator(config.CodeGenType, config.CodeGenSettings))
						{
							cg.Generate(tree, ct.Token);
						}
					}

					if (config.ResGenType != ResGenType.None)
					{
						using (var rg = CreateResGenerator(config.ResGenType, config.ResGenSettings))
						{
							rg.Generate(tree, ct.Token);
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

		static ILocTree[] LoadLocTrees(string path, SourceFileType type)
		{
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				if (type == SourceFileType.Auto)
				{
					if (path.EndsWith(".xml"))
					{
						type = SourceFileType.Xml;
					}
					else if (path.EndsWith(".json"))
					{
						type = SourceFileType.Json;
					}
					else
					{
						type = SourceFileType.Xliff20;
					}
				}

				using (var treeBuilder = CreateTreeBuilder(type))
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

		static ILocResGenerator CreateResGenerator(ResGenType resGenType, ILocResGeneratorSettings settings)
		{
			switch (resGenType)
			{
				case ResGenType.ResX:
					return new Impl.ResxResGenerator(settings);

				default:
					return new Impl.JsonResGenerator(settings);
			}
		}
	}
}
