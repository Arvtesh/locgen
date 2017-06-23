using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace locgen.Impl
{
	/// <summary>
	/// A JSON tree builder.
	/// </summary>
	internal sealed class JsonTreeBuilder : LocTreeBuilder
	{
		#region data
		#endregion

		#region interface

		public JsonTreeBuilder()
			: base(SourceFileType.Json.ToString())
		{
		}

		#endregion

		#region LocTreeBuilder

		protected override ILocTree[] ReadInternal(Stream stream)
		{
			using (var textStream = new StreamReader(stream))
			{
				using (var textStreamReader = new JsonTextReader(textStream))
				{
					var serializer = JsonSerializer.Create();
					var tree = serializer.Deserialize<JsonDataTree>(textStreamReader);
				}
			}

			throw new NotImplementedException();
		}

		#endregion

		#region implementation
		#endregion
	}
}
