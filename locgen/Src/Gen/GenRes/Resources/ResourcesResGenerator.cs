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
	internal sealed class ResourcesResGenerator : LocResGenerator
	{
		#region data
		#endregion

		#region interface

		public ResourcesResGenerator(LocResGeneratorSettings settings)
			: base(ResGenType.Resources.ToString(), settings)
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
			return ".resources";
		}

		#endregion

		#region implementation
		#endregion
	}
}
