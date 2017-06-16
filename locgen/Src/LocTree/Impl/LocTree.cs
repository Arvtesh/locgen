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
	internal class LocTree : LocTreeGroup, ILocTree, ILocTreeSettings
	{
		#region data
		#endregion

		#region interface

		public LocTree(string name)
			: base(null, name)
		{
		}

		#endregion

		#region ILocTree

		public ILocTreeSettings Settings => this;

		#endregion
	}
}
