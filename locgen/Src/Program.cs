using System;
using System.Threading;
using System.IO;

namespace locgen
{
	class Program
	{
		static void Main(string[] args)
		{
			var ct = new CancellationTokenSource();
			ILocTree tree;

			using (var stream = new FileStream("c:\\Users\\1\\Documents\\test.xliff", FileMode.Open, FileAccess.Read))
			{
				using (var treeBuilder = new Impl.XliffTreeBuilder())
				{
					tree = treeBuilder.Read(stream)[0];
				}
			}

			using (var cg = new CodeGen.CsharpCodeGenerator())
			{
				cg.Settings.TargetPath = "c:\\Users\\1\\Documents\\test.generated.cs";
				cg.Settings.TargetNamespace = "SampleNamespace";
				cg.Settings.GenerateLocKeys = true;
				cg.Generate(tree, ct.Token);
			}
		}
	}
}
