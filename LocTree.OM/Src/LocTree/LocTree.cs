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
	public class LocTree : LocTreeGroup
	{
		#region data
		#endregion

		#region interface

		public LocTree(string id, string name)
			: base(null, id, name)
		{
		}

		#endregion
	}
}
