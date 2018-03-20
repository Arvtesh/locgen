using System;
using System.Collections.Generic;
using System.Text;

namespace locgen
{
	internal class JsonDataUnit : JsonDataItem
	{
		public string Type { get; set; }
		public string SrcValue { get; set; }
		public string TargetValue { get; set; }
		public string SrcPath { get; set; }
		public string TargetPath { get; set; }
	}
}
