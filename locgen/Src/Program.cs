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
			var config = FromArgs(args);

			Console.WriteLine($"{assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description} v{assemblyName.Version}.");

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
			else
			{
				// TODO
			}
		}

		static ILocConfig FromArgs(string[] args)
		{
			var result = new Impl.LocConfig();

			result.CodeGenType = CodeGenType.Csharp;
			result.SourceFileType = SourceFileType.Xliff20;
			result.SourceFilePath = "./../Samples/text.xlf";
			result.CodeGenSettings.TargetDir = "c:/Users/Alex/Documents/";
			result.CodeGenSettings.TargetNamespace = "SampleNamespace";
			result.CodeGenSettings.GenerateLocKeys = false;
			result.CodeGenSettings.StaticAccess = true;

			return result;
		}

		static ILocTree[] LoadLocTrees(ILocConfig config)
		{
			using (var stream = new FileStream(config.SourceFilePath, FileMode.Open, FileAccess.Read))
			{
				using (var treeBuilder = CreateTreeBuilder(config.SourceFileType))
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
					throw new NotImplementedException();
			}
		}
	}
}
