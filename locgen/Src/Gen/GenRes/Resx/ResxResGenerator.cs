using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A ResX resource file generator.
	/// </summary>
	internal sealed class ResxResGenerator : LocResGenerator
	{
		#region data
		#endregion

		#region interface

		public ResxResGenerator(ILocResGeneratorSettings settings)
			: base(ResGenType.ResX.ToString(), settings)
		{
		}

		#endregion

		#region LocCodeGenerator

		protected override void GenerateInternal(ILocTree data, StreamWriter file, CancellationToken cancellationToken)
		{
			WriteIdent(file, 0, "<?xml version=\"1.0\" encoding=\"utf-8\"?>");
			WriteIdent(file, 0, "<root>");
			WriteIdent(file, 1, "<resheader name=\"resmimetype\"><value>text/microsoft-resx</value></resheader>");
			WriteIdent(file, 1, "<resheader name=\"version\"><value>2.0</value></resheader>");

			foreach (var unit in data.UnitsRecursive.OfType<ILocTreeText>())
			{
				WriteIdent(file, 1, $"<data name=\"{unit.Id}\" xml:space=\"preserve\">");
				WriteIdent(file, 2, $"<value>{unit.TargetValue}</value>");
				WriteIdent(file, 1, "</data>");
			}

			WriteIdent(file, 0, "</root>");
		}

		protected override string GetTargetFileExtension()
		{
			return ".resx";
		}

		#endregion

		#region implementation
		#endregion
	}
}
