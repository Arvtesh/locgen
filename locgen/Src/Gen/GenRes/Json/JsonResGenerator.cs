using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// A Json resource file generator.
	/// </summary>
	internal sealed class JsonResGenerator : LocResGenerator
	{
		#region data
		#endregion

		#region interface

		public JsonResGenerator(LocResGeneratorSettings settings)
			: base(ResGenType.Json.ToString(), settings)
		{
		}

		#endregion

		#region LocCodeGenerator

		protected override void GenerateInternal(LocTree data, string path, CancellationToken cancellationToken)
		{
			using (var file = File.CreateText(path))
			{
				WriteIdent(file, 0, "{");
				WriteIdent(file, 1, "\"strings\":[");

				foreach (var unit in data.UnitsRecursive.OfType<LocTreeText>())
				{
					var value = string.IsNullOrEmpty(unit.TargetValue) ? unit.SrcValue : unit.TargetValue;

					WriteIdent(file, 2, "{");
					WriteIdent(file, 3, $"\"id\": \"{unit.Id}\"");
					WriteIdent(file, 3, $"\"value\": \"{value}\"");
					WriteIdent(file, 2, "}");
				}

				WriteIdent(file, 1, "]");
				WriteIdent(file, 0, "}");
			}
		}

		protected override string GetTargetFileExtension()
		{
			return ".json";
		}

		#endregion

		#region implementation
		#endregion
	}
}
