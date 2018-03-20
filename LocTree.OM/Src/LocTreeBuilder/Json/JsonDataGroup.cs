using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	internal class JsonDataGroup : JsonDataItem
	{
		public JsonDataGroup[] Groups { get; set; }
		public JsonDataUnit[] Units { get; set; }
	}
}
