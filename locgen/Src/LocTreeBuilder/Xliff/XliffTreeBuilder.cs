using System;
using System.Collections.Generic;
using System.IO;
using Localization.Xliff.OM;
using Localization.Xliff.OM.Core;
using Localization.Xliff.OM.Serialization;

namespace locgen.Impl
{
	/// <summary>
	/// A XLIFF tree builder.
	/// </summary>
	internal sealed class XliffTreeBuilder : LocTreeBuilder
	{
		#region data
		#endregion

		#region interface

		public XliffTreeBuilder()
			: base("XLIFF")
		{
		}

		#endregion

		#region LocTreeBuilder

		protected override ILocTree[] ReadInternal(Stream stream)
		{
			var reader = new XliffReader();
			var doc = reader.Deserialize(stream);
			var files = doc.Files;
			var result = new ILocTree[files.Count];

			for (int i = 0; i < result.Length; ++i)
			{
				result[i] = ReadTree(files[i]);
			}

			return result;
		}

		#endregion

		#region implementation

		private ILocTree ReadTree(Localization.Xliff.OM.Core.File file)
		{
			var tree = new LocTree(file.Id);
			return tree;
		}

		#endregion
	}
}
