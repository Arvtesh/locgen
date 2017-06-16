using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeItem"/>.
	/// </summary>
	internal abstract class LocTreeItem : ILocTreeItem
	{
		#region data

		private readonly ILocTreeItem _parent;
		private readonly string _id;
		private readonly string _name;

		#endregion

		#region interface

		protected LocTreeItem(ILocTreeItem parent, string name)
		{
			_parent = parent;
			_name = name;

			if (parent != null)
			{
				_id = (parent.Id + '_' + name).ToLowerInvariant();
			}
			else
			{
				_id = name.ToLowerInvariant();
			}
		}

		#endregion

		#region ILocTreeItem

		public string Id => _id;
		public string Name => _name;
		public string Notes { get; set; }

		#endregion
	}
}
