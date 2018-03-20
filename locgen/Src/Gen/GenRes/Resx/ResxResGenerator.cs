using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Resources;

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

		public ResxResGenerator(LocResGeneratorSettings settings)
			: base(ResGenType.ResX.ToString(), settings)
		{
		}

		#endregion

		#region LocCodeGenerator

		protected override void GenerateInternal(LocTree data, string path, CancellationToken cancellationToken)
		{
			using (var resGen = new ResourceWriter(path))
			{
				foreach (var unit in data.UnitsRecursive.OfType<LocTreeText>())
				{
					var value = string.IsNullOrEmpty(unit.TargetValue) ? unit.SrcValue : unit.TargetValue;
					resGen.AddResource(unit.Id, value);
				}

				resGen.Generate();
			}
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
