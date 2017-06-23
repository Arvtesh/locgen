using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeText"/>.
	/// </summary>
	internal sealed class LocTreeText : LocTreeUnit, ILocTreeText
	{
		#region data



		#endregion

		#region interface

		public LocTreeText(ILocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion

		#region ILocTreeUnit

		public string SrcValue { get; set; }
		public string TargetValue { get; set; }

		#endregion
	}
}
