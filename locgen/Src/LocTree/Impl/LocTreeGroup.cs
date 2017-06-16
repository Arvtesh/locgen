using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading;

namespace locgen.Impl
{
	/// <summary>
	/// Implementation of <see cref="ILocTreeGroup"/>.
	/// </summary>
	internal class LocTreeGroup : LocTreeItem, ILocTreeGroup
	{
		#region data

		private List<ILocTreeGroup> _groups = new List<ILocTreeGroup>();
		private List<ILocTreeUnit> _units = new List<ILocTreeUnit>();

		#endregion

		#region interface

		public LocTreeGroup(ILocTreeItem parent, string name)
			: base(parent, name)
		{
		}

		#endregion

		#region ILocTreeGroup

		public IEnumerable<ILocTreeGroup> Groups => _groups;
		public IEnumerable<ILocTreeUnit> Units => _units;

		public ILocTreeUnit AddUnit(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Invalid unit name", nameof(name));
			}

			var unit = new LocTreeUnit(this, name);
			_units.Add(unit);
			return unit;
		}

		public ILocTreeGroup AddGroup(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Invalid group name", nameof(name));
			}

			var group = new LocTreeGroup(this, name);
			_groups.Add(group);
			return group;
		}

		#endregion
	}
}
