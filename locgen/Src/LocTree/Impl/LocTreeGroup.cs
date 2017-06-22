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

		private const string _invalidIdText = "Invalid item identifier";

		private List<ILocTreeGroup> _groups = new List<ILocTreeGroup>();
		private List<ILocTreeUnit> _units = new List<ILocTreeUnit>();

		#endregion

		#region interface

		public LocTreeGroup(ILocTreeItem parent, string id, string name)
			: base(parent, id, name)
		{
		}

		#endregion

		#region ILocTreeGroup

		public IEnumerable<ILocTreeGroup> Groups => _groups;
		public IEnumerable<ILocTreeUnit> Units => _units;

		public IEnumerable<ILocTreeUnit> UnitsRecursive
		{
			get
			{
				foreach (var unit in _units)
				{
					yield return unit;
				}

				foreach (var group in _groups)
				{
					foreach (var groupUnit in group.UnitsRecursive)
					{
						yield return groupUnit;
					}
				}
			}
		}

		public ILocTreeUnit AddUnit(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(_invalidIdText, nameof(id));
			}

			var unit = new LocTreeUnit(this, id, name);
			_units.Add(unit);
			return unit;
		}

		public ILocTreeGroup AddGroup(string id, string name)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException(_invalidIdText, nameof(id));
			}

			var group = new LocTreeGroup(this, id, name);
			_groups.Add(group);
			return group;
		}

		#endregion
	}
}
