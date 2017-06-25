using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTree"/>.
	/// </summary>
	internal class LocTree : LocTreeGroup, ILocTree
	{
		#region data
		#endregion

		#region interface

		public LocTree(string id, string name)
			: base(null, id, name)
		{
		}

		#endregion

		#region ILocTree
		#endregion
	}
}
