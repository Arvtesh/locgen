using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LocTreeText : LocTreeUnit
	{
		#region data



		#endregion

		#region interface

		public string SrcValue { get; set; }
		public string TargetValue { get; set; }

		public LocTreeText(LocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion
	}
}
