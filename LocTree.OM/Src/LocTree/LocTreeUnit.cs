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
	public abstract class LocTreeUnit : LocTreeItem
	{
		#region data
		#endregion

		#region interface

		public LocTreeUnit(LocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion
	}
}
