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
	internal class LocTree : ILocTree, ILocTreeSettings
	{
		#region data
		#endregion

		#region interface
		#endregion

		#region ILocTree

		public ILocTreeSettings Settings => this;

		#endregion

		#region ILocTreeGroup

		public IEnumerable<ILocTreeGroup> Groups => throw new NotImplementedException();

		public IEnumerable<ILocTreeUnit> Units => throw new NotImplementedException();

		#endregion

		#region ILocTreeItem

		public string Id => throw new NotImplementedException();

		public string Name => throw new NotImplementedException();

		public string Notes => throw new NotImplementedException();

		#endregion
	}
}
