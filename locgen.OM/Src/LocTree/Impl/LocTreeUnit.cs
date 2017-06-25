using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeUnit"/>.
	/// </summary>
	internal abstract class LocTreeUnit : LocTreeItem, ILocTreeUnit
	{
		#region data

		

		#endregion

		#region interface

		public LocTreeUnit(ILocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion

		#region ILocTreeUnit
		#endregion
	}
}
