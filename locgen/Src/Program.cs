using System;
using System.Threading;

namespace locgen
{
	class Program
	{
		static void Main(string[] args)
		{
			var ct = new CancellationTokenSource();

			using (var cg = new CodeGen.CsharpCodeGenerator())
			{
				cg.Settings.TargetPath = "c:\\Users\\Alex\\Documents\\test.generated.cs";
				cg.Generate(new Impl.LocTree(), ct.Token);
			}
		}
	}
}
