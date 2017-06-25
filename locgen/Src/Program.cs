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

		static LocConfig FromArgs(string[] args)
		{
			var result = new LocConfig();
			var settings = new LocConfigSettings();
			settings.Parse(result, args);

			if (string.IsNullOrEmpty(result.SourceFilePath))
			{
				settings.WriteHelp();
				return null;
			}

			return result;
		}

		static ILocTreeSet LoadLocTrees(string path, LocTreeSourceType type)
		{
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				if (type == LocTreeSourceType.Auto)
				{
					if (path.EndsWith(".xml"))
					{
						type = LocTreeSourceType.Xml;
					}
					else if (path.EndsWith(".json"))
					{
						type = LocTreeSourceType.Json;
					}
					else
					{
						type = LocTreeSourceType.Xliff20;
					}
				}

				using (var treeBuilder = LocTree.CreateReader(type))
				{
					var result = LocTree.CreateSet();
					treeBuilder.Read(result, stream);
					return result;
				}
			}
		}

		static ILocCodeGenerator CreateCodeGenerator(CodeGenType codeGenType, ILocCodeGeneratorSettings settings)
		{
			switch (codeGenType)
			{
				case CodeGenType.Csharp:
				case CodeGenType.CsharpUnity3d:
					return new Impl.CsharpCodeGenerator(codeGenType, settings);

				case CodeGenType.Cpp:
					return new Impl.CppCodeGenerator(codeGenType, settings);

				default:
					return new Impl.CsharpCodeGenerator(codeGenType, settings);
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
